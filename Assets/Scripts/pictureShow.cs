// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class pictureShow : MonoBehaviour {
  private Vector3 startingPosition;

  void Start() {
    startingPosition = transform.localPosition;
	GameObject manet = GameObject.Find("manet");
	GameObject quad1 = GameObject.Find ("Quad1");
	manet.gameObject.GetComponent<Renderer> ().enabled = false;
	quad1.gameObject.GetComponent<Renderer> ().enabled = false;
    SetGazedAt(false);
  }

  public void SetGazedAt(bool gazedAt) {
    //GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
  }

  public void Reset() {
    transform.localPosition = startingPosition;
  }

  public void ToggleVRMode() {
    Cardboard.SDK.VRModeEnabled = !Cardboard.SDK.VRModeEnabled;
  }

  public void TeleportRandomly() {
    Vector3 direction = Random.onUnitSphere;
    direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
    float distance = 2 * Random.value + 1.5f;
    transform.localPosition = direction * distance;
  }

	public void showObject() {
		GameObject quad1 = GameObject.Find("Quad1");
		if (quad1.gameObject.GetComponent<Renderer> ().enabled == false){
			quad1.gameObject.GetComponent<Renderer> ().enabled = true;
		} else {
			quad1.gameObject.GetComponent<Renderer> ().enabled = false;
		}
		
	}

	public void showPicture() {
		GameObject manet = GameObject.Find("manet");
		if (manet.gameObject.GetComponent<Renderer> ().enabled == false){
			manet.gameObject.GetComponent<Renderer> ().enabled = true;
			manet.transform.position = new Vector3(-1, 1, 1);
		} else {
			manet.gameObject.GetComponent<Renderer> ().enabled = false;
			manet.transform.position = new Vector3(-3, 0, -3);
		}
		
	}}
