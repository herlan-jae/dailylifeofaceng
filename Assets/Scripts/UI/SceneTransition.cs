using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;          // Nama scene tujuan (LivingRoom)
    public Vector2 targetPosition;      // Koordinat X & Y titik muncul di scene tujuan
    public Animator fadeAnimator;       // Masukkan objek FadeScreen ke sini

    private bool isPlayerNear = false;

    void Update()
    {
        // Jika player di dekat pintu DAN menekan tombol X
        if (isPlayerNear && Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(TransitionRoutine());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) { isPlayerNear = true; }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) { isPlayerNear = false; }
    }

    // Coroutine untuk memberi jeda waktu agar animasi gelap selesai diputar
    IEnumerator TransitionRoutine()
    {
        // 1. Catat posisi kemunculan di memori statis
        PlayerSpawn.nextSpawnPosition = targetPosition;
        PlayerSpawn.isSpawning = true;

        // 2. Putar animasi layar menggelap
        if (fadeAnimator != null)
        {
            fadeAnimator.SetTrigger("StartFade");
        }

        // 3. Tunggu 1 detik (sesuaikan dengan panjang animasi FadeOut kamu)
        yield return new WaitForSeconds(1f);

        // 4. Pindah ruangan
        SceneManager.LoadScene(sceneToLoad);
    }
}