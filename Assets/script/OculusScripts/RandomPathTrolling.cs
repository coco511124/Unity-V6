using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomPathTrolling : MonoBehaviour
{
    public NavMeshAgent agent; //�ŧi�N�z�H�ݩ�
    public float range;        //���w���ߪ��b�|�d��

    [SerializeField] private bool stopOrWalk; //�M�w�n���n���U�ӡATrue�N��i���AFalse�N���U��
    public Transform headPlayer;              //������a���Y

    public Transform centrePoint;      
    //�N�z�H�Q�n���ʪ��ϰ쪺����
    //�p�G���ݭn�@�ӯS�w���ϰ쪺�ܡA�N��Trasform���Ѧҳ]���N�z�H�ۨ���Trasform
   

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stopOrWalk = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (stopOrWalk) //�p�G�ٯਫ
        {        
            if (agent.remainingDistance <= agent.stoppingDistance) //���|������
            {
                Vector3 point;
                if (RandomPoint(centrePoint.position, range, out point)) //�b�����I�M�ϰ쪺�b�|���q�L
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //�bgizmos���[��
                    agent.SetDestination(point);  //���s�]�m�N�z�H���ؼЦa
                }
            }
        }
        else
        {
            //���ਫ����
            //�N���m�N�z�H�����|�A�åB���缾�a
            agent.ResetPath();
            transform.LookAt(new Vector3(headPlayer.position.x, transform.position.y, headPlayer.position.z)); //��NPC�Y�ɭ��۪��a���Y
        }

    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //�bsphere�̭��H���D�@�I 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //���: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        {
            //1.0�O�H���I��navmesh�W�t�@���I���̤j�Z���A�p�G�d��ܤj���ܡA�i�H����󤤤@�ˡA�[��loop
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }

    public void SetWalkFalse() 
    {
        //���a����NPC���ɭԡA��stopOrWalk�]�w��false�A��NPC�I�sResetPath()�C 
        //�|��DialogTrigger�I�s
        stopOrWalk = false;
    }
    public void SetWalkTrue()  
    {
        //���a��ܧ���A��stopOrWalk�]�w��walk�A��NPC�~�򲾰�
        //�|��DialogManager�I�s
        stopOrWalk = true;
    }

}
