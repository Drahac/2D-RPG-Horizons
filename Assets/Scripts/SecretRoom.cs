using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretRoom : MonoBehaviour
{

    [SerializeField] private Tilemap hiddenTilemap;
    private BoxCollider2D boxCollider;

    private EdgeCollider2D edgeCollider;

    private BoundsInt area;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        edgeCollider = GetComponent<EdgeCollider2D>();

        Vector3Int pos = Vector3Int.FloorToInt(boxCollider.bounds.min);
        Vector3Int size = Vector3Int.FloorToInt(boxCollider.bounds.size + new Vector3Int(0,0,1));
        
        area = new BoundsInt(pos, size);


        
    }

    private void RevealRoom()
    {
        foreach (Vector3Int point in area.allPositionsWithin)
        {
            hiddenTilemap.SetTileFlags(point, TileFlags.None);
            hiddenTilemap.SetColor(point, new Color(255f, 255f, 255f, 0f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RevealRoom();
        }
    }



}
