using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface that gets called whenever there is a collisoin between
// to object. the "hit" object should call this
public interface IHittable {
    void TakeHit();
    void GiveHit(Collider2D other);
}

