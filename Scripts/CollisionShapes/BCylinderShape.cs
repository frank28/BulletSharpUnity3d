﻿using System;
using UnityEngine;
using System.Collections;
using BulletSharp;

namespace BulletUnity
{
    [AddComponentMenu("Physics Bullet/Shapes/Cylinder")]
    public class BCylinderShape : BCollisionShape
    {
        [SerializeField]
        protected Vector3 halfExtent = new Vector3(0.5f, 0.5f, 0.5f);
        public Vector3 HalfExtent
        {
            get { return halfExtent; }
            set
            {
                if (collisionShapePtr != null && value != halfExtent)
                {
                    Debug.LogError("Cannot change the extents after the bullet shape has been created. Extents is only the initial value " +
                                    "Use LocalScaling to change the shape of a bullet shape.");
                }
                else {
                    halfExtent = value;
                }
            }
        }

        public override void OnDrawGizmosSelected()
        {
            if (drawGizmo == false)
            {
                return;
            }
            UnityEngine.Vector3 position = transform.position;
            UnityEngine.Quaternion rotation = transform.rotation;
            BUtility.DebugDrawCylinder(position, rotation, LocalScaling, halfExtent.x, halfExtent.y, 1, Color.yellow);
        }

        public override CollisionShape CopyCollisionShape()
        {
            CylinderShape cs = new CylinderShape(halfExtent.ToBullet());
            cs.LocalScaling = m_localScaling.ToBullet();
            return cs;
        }

        public override CollisionShape GetCollisionShape()
        {
            if (collisionShapePtr == null)
            {
                collisionShapePtr = new CylinderShape(halfExtent.ToBullet());
                ((CylinderShape)collisionShapePtr).LocalScaling = m_localScaling.ToBullet();
            }
            return collisionShapePtr;
        }
    }
}