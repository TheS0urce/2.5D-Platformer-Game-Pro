using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private Transform _respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            CharacterController cc = other.GetComponent<CharacterController>();

            if (player != null)
            {
                player.Damage();
            }

            if(cc != null)
            {
                cc.enabled = false;
            }

            other.transform.position = _respawnPoint.transform.position;

            StartCoroutine(CCEnabled(cc));
        }
    }

    IEnumerator CCEnabled(CharacterController controller)
    {
        yield return new WaitForSeconds(0.5f);
        controller.enabled = true;
    }
}
