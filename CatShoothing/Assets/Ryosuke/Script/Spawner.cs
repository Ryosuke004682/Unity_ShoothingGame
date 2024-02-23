using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �L���X�|�[��������N���X
/// </summary>
public class Spawner : MonoBehaviour
{
    [SerializeField, Tooltip("�L�̃v���n�u���i�[")]
    protected List<GameObject> cats;
    [SerializeField, Tooltip("�v���n�u�����牽�C�����_���ŃX�|�[�������邩")]
    protected int random_pickUp;

    //�X�|�[���`������ݒ�
    public float spawning_upper_limitX = 6.0f;
    public float spawning_upper_limitY = 4.0f;

    public List<Vector2> spawn_cat_ferstPositions = new List<Vector2>();


    private void Start()
    {
        if (cats == null || cats.Count == 0) return;

        random_pickUp = Random.Range(random_pickUp , cats.Count);


        //spawnPositrions�ɒǉ������v�f����randomPickup�𒴂��Ȃ��悤�ɐ���
        for(int i = 0; i < random_pickUp && spawn_cat_ferstPositions.Count < random_pickUp; i++)
        {
            int random_create_actor = Random.Range(0 , random_pickUp);
            Vector2 spawn_cat_position = GetvalidSpawnPosition();

            if (spawn_cat_position == Vector2.zero) break;


            GameObject new_cat = Instantiate
                (cats[random_create_actor] , spawn_cat_position , Quaternion.identity);

            CatController cat_controller = new_cat.GetComponent<CatController>();
            
            if(cat_controller != null)
            {
                cat_controller.SetStartPosition(spawn_cat_position);
            }
            spawn_cat_ferstPositions.Add(spawn_cat_position);
        }
    }

    /// <summary>
    /// �X�|�[������|�W�V�����������_���Ɏw��
    /// </summary>
    /// <returns></returns>
    private Vector2 GetvalidSpawnPosition()
    {
        int number_of_attemots = 0;
        Vector2 spawn_position = Vector2.zero;

        //���s�񐔂�100�܂łƂ���
        while(number_of_attemots < 100)
        {
            spawn_position = new Vector2
                (Random.Range(-spawning_upper_limitX, spawning_upper_limitX)
               , Random.Range(1, spawning_upper_limitY + 1));

            if (IsPositionValid(spawn_position)) return spawn_position;

            number_of_attemots++;
        }
        return Vector2.zero;
    }


    /// <summary>
    /// �d�Ȃ��ăX�|�[�����Ȃ����ǂ����̃`�F�b�N
    /// </summary>
    /// <returns></returns>
    public bool IsPositionValid(Vector2 position)
    {
        foreach(Vector2 spawn_cat_position in spawn_cat_ferstPositions)
        {
            if (Vector2.Distance(position, spawn_cat_position) < 1.0f) return false;
        }

        return true;
    }



}