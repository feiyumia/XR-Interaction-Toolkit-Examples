﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityEngine.XR.Interaction.Toolkit
{

    public class containerlayer : MonoBehaviour
    {
        int max;
        private float containerObjectRadius = 0.05f;
        private int Rmax;
        private int Cmax;
        private int Rlast = 0;
        private int Clast = 0;
        private int RlastforSocket = 0;
        private int ClastforSocket = 0;
        private float buffery = 0.2f;
        private float bufferz = 0.2f;
        public float layervalue = 0f;
        public List<containerobject> containerobjectlist = new List<containerobject>();
        public List<containersocket> containersocketlist = new List<containersocket>();
        public void AddObject(GameObject go)
        {
            go.name = "CO "+containerobjectlist.Count;
            containerobject co = go.GetComponent<containerobject>();
            containerobjectlist.Add(co);

            //int currentIndex = containerobjectlist.Count;
            //containersocketlist[currentIndex].
            TraditionalAddObject(co);
        }
        void TraditionalAddObject(containerobject co)
        {

            //co.transform.position = this.transform.position + Vector3.up * 0.5f * containerobjectlist.Count;
            //Place object
            int Ri;
            int Ci;
            //print("set position:");
            Ri = Rlast;
            //print("Ri: " + Ri);
            Ci = Clast;
            // print("Ci: " + Ci); 
            float x = this.transform.position.x + (Ci * buffery) - 0.2f;
            float y = this.transform.position.y + (Ri * bufferz) - 0.2f;
            float z = this.transform.position.z;
            co.transform.position = new Vector3(x, y, z);
            co.transform.SetParent(this.transform);
            //Calculate Next Position
            Ci++;
            // print("calculate position");
            if (Ci >= Cmax)
            {
                Ci = 0;
                //print("Ci = "+Ci);
                Ri++;
                //print("Ri= " + Ri);
            }
            Rlast = Ri;
            // print("Rlast is" + Rlast);
            Clast = Ci;
            //print("Clast is" + Clast); 
            if (Clast >= Cmax && Rlast >= Rmax)
            {
                // print("is full");
            }
        }
        public void AddObjectSocket(GameObject go)
        {
            containersocket cs = go.GetComponent<containersocket>();
            cs.name = "CS " + containersocketlist.Count;
            containersocketlist.Add(cs);
            //co.transform.position = this.transform.position + Vector3.up * 0.5f * containerobjectlist.Count;
            //Place object
            int Ri;
            int Ci;
            //print("set position:");
            Ri = RlastforSocket;
            //print("Ri: " + Ri);
            Ci = ClastforSocket;
            // print("Ci: " + Ci); 
            float x = this.transform.position.x + (Ci * buffery) - 0.2f;
            float y = this.transform.position.y + (Ri * bufferz) - 0.2f;
            float z = this.transform.position.z;
            cs.transform.position = new Vector3(x, y, z);
            cs.transform.SetParent(this.transform);
            //Calculate Next Position
            Ci++;
            // print("calculate position");
            if (Ci >= Cmax)
            {
                Ci = 0;
                //print("Ci = "+Ci);
                Ri++;
                //print("Ri= " + Ri);
            }
            RlastforSocket = Ri;
            // print("Rlast is" + Rlast);
            ClastforSocket = Ci;
            //print("Clast is" + Clast); 
            if (ClastforSocket >= Cmax && RlastforSocket >= Rmax)
            {
                // print("is full");
            }
        }
        public int GetMax()
        {
            float a = this.transform.localScale.x;
            float b = this.transform.localScale.y;
            float c = this.transform.localScale.z;
            Cmax = (int)(c / (buffery + (containerObjectRadius * 2)));
            // print("Cmax is "+ Cmax);
            Rmax = (int)(b / (bufferz + (containerObjectRadius * 2)));
            max = Cmax * Rmax;
            return max;
        }
        public bool IsFull()
        {
            max = Cmax * Rmax;

            //  print("Is Full: " + (containerobjectlist.Count >= max));
            return containerobjectlist.Count >= max;
        }
        // Start is called before the first frame update
        void Awake()
        {
            //x = this.GetComponent<Collider>().bounds.size.x;// PF_layerObject.collider.bounds.size.x;
            //z = this.GetComponent<Collider>().bounds.size.z; //PF_layerObject.collider.bounds.size.z;
            //y = this.GetComponent<Collider>().bounds.size.y;// PF_layerObject.collider.bounds.size.y;
            float a = this.transform.localScale.x;
            float b = this.transform.localScale.y;
            float c = this.transform.localScale.z;
            Cmax = (int)(c / (buffery + (containerObjectRadius * 2)));
            // print("Cmax is "+ Cmax);
            Rmax = (int)(b / (bufferz + (containerObjectRadius * 2)));
            // print("Rmax is "+ Rmax);
            //print(containerObjectRadius);
            //IsFull();
        }
        // Update is called once per frame
        void Update()
        {
        }

        public void hidecontainerobject()
        {
            for (int i=0;i<containerobjectlist.Count;i++)
            {
               containerobjectlist[i].gameObject.SetActive(false);
            }
        }

        public void showcontainerobject()
        {
            for (int i = 0; i < containerobjectlist.Count; i++)
            {
                containerobjectlist[i].gameObject.SetActive(true);
            }
        }
    }
}