using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisLike : MonoBehaviour
{

    [SerializeField] private GameObject part1, part2, part3, part4;
    private const float POS_X = 0.5f, POS_Y_1 = 1.5f, POS_Y_2 = 2.0f, TOLERATED_OFFSET = 0.5f, Z_AXIS = 0.0f, LINEAR_DRAG = 10.0f;
    [SerializeField] private bool _state;
    [SerializeField] private GameObject bird;

    // Start is called before the first frame update
    void Start()
    {
        _state = false;

        // On initialise les linear drag à 10 pour éviter qu'ils glisses
        part1.GetComponent<Rigidbody2D>().drag = LINEAR_DRAG;
        part2.GetComponent<Rigidbody2D>().drag = LINEAR_DRAG;
        part3.GetComponent<Rigidbody2D>().drag = LINEAR_DRAG;
        part4.GetComponent<Rigidbody2D>().drag = LINEAR_DRAG;
    }

    private bool isInPostition(GameObject part, float posX, float posY)
    {
        return (part.transform.position == new Vector3(posX, posY, Z_AXIS));
    }

    private bool placeInPosition(GameObject part, float posX, float posY)
    {
        if( part.transform.position.x < posX + TOLERATED_OFFSET + transform.position.x && 
            part.transform.position.x > posX - TOLERATED_OFFSET + transform.position.x &&
            part.transform.position.y < posY + TOLERATED_OFFSET + transform.position.y &&
            part.transform.position.y > posY - TOLERATED_OFFSET + transform.position.y)
        {
            part.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            part.transform.position = new Vector3(posX + transform.position.x, posY + transform.position.y, Z_AXIS);
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log(transform.rotation.eulerAngles.z);

        bool test_part_1 = isInPostition(part1, POS_X, POS_Y_1),
            test_part_2 = isInPostition(part2, -POS_X, -POS_Y_2),
            test_part_3 = isInPostition(part3, -POS_X, POS_Y_1),
            test_part_4 = isInPostition(part4, POS_X, -POS_Y_1);

        // on test la position de chaque parties et si elle ne sont pas à leurs position on regarde si elles peuvent y être PUTAIN DE GIT
        if (!test_part_1)
            test_part_1 = placeInPosition(part1, POS_X, POS_Y_1);
        if (!test_part_2)
            test_part_2 = placeInPosition(part2, -POS_X, -POS_Y_2);
        if (!test_part_3)
            test_part_3 = placeInPosition(part3, -POS_X, POS_Y_1);
        if (!test_part_4)
            test_part_4 = placeInPosition(part4, POS_X, -POS_Y_1);

        if (test_part_1 && test_part_2 && test_part_3 && test_part_4)
            _state = true;


        bird.SetActive(_state);
    }


    public bool state
    {
        get { return _state; }
    }
}
