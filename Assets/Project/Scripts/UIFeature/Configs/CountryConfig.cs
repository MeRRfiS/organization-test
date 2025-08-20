using UnityEngine;
using System.Collections.Generic;
using Assets.Project.Scripts.UIFeature.Models;

namespace Assets.Project.Scripts.UIFeature.Config
{
	[CreateAssetMenu(fileName = "CountryConfig", menuName = "Scriptable Objects/CountryConfig")]
	public class CountryConfig : ScriptableObject
	{
		[field: SerializeField] public List<CountryModel> Models { get; private set; } = new List<CountryModel>();
    } 
}
