using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineEnemyPush : MonoBehaviour
{
    //[SerializeField] private AudioClip[] _audioClips = null;

    //private int _damage = 0;
    //private Collider _collider = null;
    //private bool _onTriggerStay = false;
    //private AudioSource _explodeAudio = null;
    //public void Init(int damage)
    //{
    //    _damage = damage;
    //}
    //private void FixedUpdate()
    //{
    //    if (gameObject.GetComponentInChildren<MineDamage>()._enterFlag && !_onTriggerStay)
    //    {
    //        Destroy(gameObject);
    //    }
    //    if (_onTriggerStay)
    //    {
    //        Push();
    //    }
    //}
    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //        _collider = other;
    //        _onTriggerStay = true;
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Enemy"))
    //    {
    //       _collider = null;
    //       _onTriggerStay = false;
    //        _explodeAudio.PlayOneShot(_audioClips[0]);
    //    }
    //}
    //private void Push()
    //{
    //    if (gameObject.GetComponentInChildren<MineDamage>()._enterFlag)
    //    {
    //     _collider.attachedRigidbody.GetComponentInParent<Transform>().Translate(Vector3.forward * -5);
    //     _collider.gameObject.GetComponentInParent<ITakeDamage>().TakeDamage(_damage);
    //    }
    //}
}
