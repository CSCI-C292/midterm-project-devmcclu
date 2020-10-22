using UnityEngine;

[CreateAssetMenu(menuName = "Inventory")]
public class Inventory : ScriptableObject
{
    public enum Guns
    {
        Knife,
        Pistol,
        Shotgun,
        Rifle,
        RocketLauncher
    }
    
    public Guns CurrentGun;
    public bool[] HaveGun = new bool[] {true, false, false, false, false};
    public int[] Ammo = new int[5];
    public GameObject[] AmmoPrefab = new GameObject[5];
    public float[] FireTimer = new float[5];
}