using UnityEngine;

public static class RandomNumbers
{
    // Genera números aleatorios con una distribución normal de probabilidad
    // con media [mu] y desviación estándar [sigma]
    public static float NormalRandomNumber(float mu, float sigma)
    {
        float r1 = Random.value;
        float r2 = Random.value;

        float q1 = Mathf.Sqrt(-2 * Mathf.Log(r1)) * Mathf.Cos(2 * Mathf.PI * r2);
        float normalRandomNumber = mu + q1 * sigma;

        //float q2 = Mathf.Sqrt(-2 * Mathf.Log(r1)) * Mathf.Sin(2 * Mathf.PI * r2);
        //float normalRandomNumber = mu + q2 * sigma;

        return normalRandomNumber;
    }

    // Genera números aleatorios con una distribución exponencial de probabilidad
    // con parametro lambda dado (media = 1/lambda)
    public static float ExponentialRandomNumber(float lambda)
    {
        float r = Random.value;
        float exponentialRandomNumber = -Mathf.Log(1f - r) / lambda;
        return exponentialRandomNumber;
    }

    // Genera números aleatorios con una distribución de pareto
    // con parametros [xm] y [alpha]
    public static float ParetoRandomNumber(float xm, float alpha)
    {
        float r = Random.value;
        float paretoRandomNumber = xm / Mathf.Pow(1.0f - r, 1.0f / alpha);
        return paretoRandomNumber;
    }

    // Genera números aleatorios con una distribución gamma
    // con parametros [alpha] y [lambda]

    public static float GammaRandomNumber(float alpha, float lambda)
    {
        if (alpha <= 0f)
        {
            Debug.LogError("El parámetro alpha debe ser positivo.");
            return 0f;
        }

        // Caso α < 1: usa recurrencia
        if (alpha < 1f)
        {
            float u = Random.value;
            return GammaRandomNumber(alpha + 1f, 1 / lambda) * Mathf.Pow(u, 1f / alpha);
        }

        // Método de Marsaglia y Tsang (2000)
        float d = alpha - 1f / 3f;
        float c = 1f / Mathf.Sqrt(9f * d);

        while (true)
        {
            // 1. Generar normal estándar (Box-Muller)
            float u1 = 1.0f - Random.value;
            float u2 = 1.0f - Random.value;
            float x = Mathf.Sqrt(-2.0f * Mathf.Log(u1)) * Mathf.Cos(2.0f * Mathf.PI * u2);

            // 2. Calcular v
            float v = 1f + c * x;
            if (v <= 0f) continue;  // debe ser positivo
            v = v * v * v;

            // 3. Generar u uniforme
            float u = Random.value;

            // 4. Condiciones de aceptación
            if (u < 1f - 0.0331f * (x * x) * (x * x))
                return d * v / lambda;

            if (Mathf.Log(u) < 0.5f * x * x + d * (1f - v + Mathf.Log(v)))
                return d * v / lambda;
        }
    }


    // Genera números aleatorios con una distribución Beta
    // con parametros [alpha] y [beta]
    public static float BetaRandomNumber(float alpha, float beta)
    {
        float r1 = GammaRandomNumber(alpha, 1f);
        float r2 = GammaRandomNumber(beta, 1f);
        return r1 / (r1 + r2);
    }

    // Genera números aleatorios con una distribución Binomial.
    // con parámetros [n] número de ensayos, [p] probabilidad de éxito.
    // Devuelve el número de exitos bajo esas condiciones.
    public static int BinomialRandomNumber(int n, float p)
    {
        float r = Random.value;
        int exitos = 0;

        for (int i = 0; i < n; i++)
        {
            if (r < p)
                exitos++;
        }
        return exitos;
    }

    public static int PoissonRandomNumber(float lambda)
    {
        float L = Mathf.Exp(-lambda);
        int k = 0;
        float p = 1f;
        do
        {
            k++;
            p *= Random.value;
        }
        while (p > L);

        return k - 1;
    }

}
