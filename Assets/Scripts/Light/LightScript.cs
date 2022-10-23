using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public float angle;
    public float maxRange;

    public int numOfRays;

    public bool debugDrawRays = false;

    private const int SPRITE_TEXTURE_SIZE = 100; // Needs to be much bigger than the max range of the raycasts
    SpriteRenderer spriteRenderer;
    SpriteMask spriteMask;
    PolygonCollider2D polygonCollider;

    private Sprite makeSpriteFromHits(List<Vector2> hitPoints, Texture2D texture){
        Vector2 spritePivot = new Vector2(SPRITE_TEXTURE_SIZE / 2f, SPRITE_TEXTURE_SIZE / 2f);

        List<Vector2> spritePoints = new List<Vector2>();
        foreach(Vector2 v in hitPoints){
            spritePoints.Add((Vector2)transform.InverseTransformVector(v - (Vector2)transform.position) + spritePivot);
        }
        spritePoints.Add(spritePivot); // Function is dif with pivot/middle, plus add to transform to get world coordinates, so want to do inverse

        ushort[] newTriangles = new ushort[3 * (hitPoints.Count - 1)];
        for(int i = 0; i < hitPoints.Count - 1; i++){
            newTriangles[3*i] = (ushort)(spritePoints.Count - 1);
            newTriangles[3*i+1] = (ushort)(i);
            newTriangles[3*i + 2] = (ushort)(i+1);
        }
        
        // Updating sprite
        Sprite sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), pixelsPerUnit: 1);
        sprite.OverrideGeometry(spritePoints.ToArray(), newTriangles);
        return sprite;
    }
    
    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
        spriteMask = GetComponent<SpriteMask>();
    }

    // Update is called once per frame
    void Update()
    {
        List<Vector2> hitPoints = new List<Vector2>();
        List<Vector2> limitPoints = new List<Vector2>();

        for(int i = 0; i < numOfRays; i++){
            float rayAngle = i * (angle / (numOfRays - 1));
            float effectiveAngle = rayAngle - (angle / 2);
            effectiveAngle += transform.eulerAngles.z;
            Vector2 absoluteVector = new Vector2(Mathf.Cos(Mathf.Deg2Rad * effectiveAngle), Mathf.Sin(Mathf.Deg2Rad * effectiveAngle));

            // Cast a ray.
            RaycastHit2D hit = Physics2D.Raycast(transform.position, absoluteVector, distance: maxRange);
            Vector2 limitPoint = (Vector2)transform.position + (absoluteVector * maxRange);
 
            // If it hits something...
            if (hit.collider != null)
            {

                hitPoints.Add(hit.point);
            } else {
                hitPoints.Add(limitPoint);
            }

            // Always add the limit points
            limitPoints.Add(limitPoint);
        }

        // Debug drawing
        if(debugDrawRays){
            foreach(Vector2 v in hitPoints){
                Debug.DrawRay(transform.position, v - (Vector2)transform.position , Color.green);
            }
        }   
        
        // Generating points and triangles
        // Updating sprite
        
        Texture2D spriteTexture = new Texture2D(SPRITE_TEXTURE_SIZE, SPRITE_TEXTURE_SIZE);
        Sprite sprite = makeSpriteFromHits(hitPoints, spriteTexture);
        spriteRenderer.sprite = sprite;
        spriteMask.sprite = sprite;

        // Updating collider
        List<Vector2> colliderPoints = new List<Vector2>();
        foreach(Vector2 v in hitPoints){
            colliderPoints.Add((Vector2)transform.InverseTransformVector(v - (Vector2)transform.position));
        }
        colliderPoints.Add(Vector2.zero); 

        polygonCollider.points = colliderPoints.ToArray();
    }
}
