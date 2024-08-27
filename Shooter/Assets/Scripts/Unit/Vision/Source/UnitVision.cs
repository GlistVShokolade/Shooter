using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class UnitVision
{
    private readonly WaitForSeconds _delay;

    private readonly float _viewRadius;

    public Transform Transform { get; }

    public event Action<Player> PlayerDetected;
    public event Action PlayerLosted;

    public UnitVision(float viewRadius, float researchDelay, Transform transform)
    {
        _delay = new WaitForSeconds(researchDelay);
        _viewRadius = viewRadius;

        Transform = transform;
    }

    public IEnumerator Scan()
    {
        while (true)
        {
            foreach (Player player in PlayerBuffer.Players)
            {
                if (player.Health.IsDied)
                {
                    continue;
                }

                float distance = Vector3.Distance(Transform.position, player.transform.position);

                if (distance > _viewRadius)
                {
                    continue;
                }

                OnDetect();

                PlayerDetected?.Invoke(player);
            }

            yield return _delay;
        }
    }

    protected virtual void OnLost() { }
    protected virtual void OnDetect() { }
}