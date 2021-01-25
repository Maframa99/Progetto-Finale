using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Music_Select : MonoBehaviour
{
    
	public GameObject Label; 
	
	public GameObject[] MusicList;
	
	private GameObject Selected_Music;
	
	public void handleinputdata ()
	{
		
		Text Testo = Label.GetComponent<Text>();
		
		/*foreach(GameObject child in MusicList)
		{
			if(child[==Testo.ToString()]
			
			{
				
				Selected_Music=child;
			}
			
		}*/
		
		for (int i=0; i<MusicList.Length;i++)
		{
			if(MusicList[i].name==Testo.ToString())
			{
				Selected_Music=MusicList[i];
			}	
		}
		Debug.Log (Selected_Music);
	}

}
