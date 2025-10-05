using UnityEngine;

public class Esfera : MonoBehaviour
{
    public GameObject spherePrefab; // Prefab de la esfera
    public GameObject spawnPlane;   // Plano donde aparecerán las esferas

    public void SpawnSphere()
    {
        if (spawnPlane == null || spherePrefab == null)
        {
            Debug.LogError("Debes asignar el prefab y el plano.");
            return;
        }

        // Obtener tamaño del plano
        Vector3 planeScale = spawnPlane.transform.localScale;
        Vector3 spawnAreaSize = new Vector3(10 * planeScale.x, 0, 10 * planeScale.z);

        // Posición aleatoria
        Vector3 randomPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
            spawnPlane.transform.position.y + 1f, // altura sobre el plano
            Random.Range(-spawnAreaSize.z / 2f, spawnAreaSize.z / 2f)
        );

        // Ajustar posición relativa
        randomPosition += spawnPlane.transform.position;

        // Crear la esfera
        Instantiate(spherePrefab, randomPosition, Quaternion.identity);
    }
}
