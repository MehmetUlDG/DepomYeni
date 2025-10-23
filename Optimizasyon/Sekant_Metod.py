import sympy as sp
import numpy as np


def hybrid_secant_method(start0, start1, funct_str, iteration):
    """
    Her iterasyonda 'Normal Sekant' ve 'Sabit Çapalı Sekant' yöntemlerini
    karşılaştıran ve f'(x) değerini sıfıra daha çok yaklaştıran (mutlak
    değeri daha küçük olan) adayı seçerek ilerleyen hibrit bir yöntem.
    """
    x = sp.Symbol('x')
    try:
        sym_f = sp.sympify(funct_str)
    except sp.SympifyError:
        print("Geçersiz fonksiyon girdisi!")
        return

    # 1. Sembolik 1. türevi al
    df_dx = sp.diff(sym_f, x)

    # 2. 1. türevi sayısal fonksiyona çevir
    try:
        f_prime_num = sp.lambdify(x, df_dx, 'numpy')
    except Exception as e:
        print(f"Fonksiyon lambdify edilemedi. Hata: {e}")
        return

    # --- Başlangıç Noktaları ---
    # Sabit çapa (hiç değişmeyecek)
    x_anchor = float(start0)
    f_prime_anchor = f_prime_num(x_anchor)  # Türevini bir kez hesapla

    # Normal Sekant için iki hareketli nokta
    x_prev = float(start0)  # x_{k-1} rolünde
    x_curr = float(start1)  # x_k rolünde

    print(f"Fonksiyon: {sym_f}")
    print(f"f'(x): {df_dx}\n")
    print(f"Sabit Çapa (x_0): {x_anchor:.6f} (f'({x_anchor:.4f}) = {f_prime_anchor:.6f})")
    print(f"Başlangıç (x_1): {x_curr:.6f}\n")

    for i in range(iteration):
        print(f"--- İterasyon {i} ---")
        print(f"x_prev (x_{i})   = {x_prev:.6f}")
        print(f"x_curr (x_{i + 1}) = {x_curr:.6f}")

        # Gerekli türev değerlerini al
        f_prime_prev = f_prime_num(x_prev)
        f_prime_curr = f_prime_num(x_curr)

        # --- Aday 1: Normal Sekant Hesaplaması ---
        # x_{k+2} = x_k - f'(x_k) * (x_k - x_{k-1}) / (f'(x_k) - f'(x_{k-1}))
        x_next_normal = None
        f_prime_normal = np.inf  # Başlangıçta sonsuz ata

        denominator_normal = (f_prime_curr - f_prime_prev)
        if np.abs(denominator_normal) > 1e-10:
            x_next_normal = x_curr - f_prime_curr * (x_curr - x_prev) / denominator_normal
            f_prime_normal = f_prime_num(x_next_normal)
            print(f"  Aday 1 (Normal): x_{i + 2} = {x_next_normal:.6f} (f' = {f_prime_normal:.6f})")
        else:
            print("  Aday 1 (Normal): Başarısız (Payda sıfır)")

        # --- Aday 2: Sabit Çapalı Sekant Hesaplaması ---
        # x_{k+2} = x_0 - f'(x_0) * (x_k - x_0) / (f'(x_k) - f'(x_0))
        # (Not: x_k = x_curr, x_0 = x_anchor)
        x_next_fixed = None
        f_prime_fixed = np.inf  # Başlangıçta sonsuz ata

        denominator_fixed = (f_prime_curr - f_prime_anchor)
        if np.abs(denominator_fixed) > 1e-10:
            x_next_fixed = x_anchor - f_prime_anchor * (x_curr - x_anchor) / denominator_fixed
            f_prime_fixed = f_prime_num(x_next_fixed)
            print(f"  Aday 2 (Sabit):  x_{i + 2} = {x_next_fixed:.6f} (f' = {f_prime_fixed:.6f})")
        else:
            print("  Aday 2 (Sabit):  Başarısız (Payda sıfır)")

        # --- Karar Verme Aşaması ---
        chosen_x = None

        # |f'(aday1)| ile |f'(aday2)| karşılaştır
        if np.abs(f_prime_normal) < np.abs(f_prime_fixed):
            chosen_x = x_next_normal
            print(f"  Karar: Normal Sekant seçildi (daha iyi: |{f_prime_normal:.6f}| < |{f_prime_fixed:.6f}|)")
        elif np.abs(f_prime_fixed) < np.inf:  # Eğer 'fixed' geçerliyse (sonsuz değilse)
            chosen_x = x_next_fixed
            print(f"  Karar: Sabit Çapa seçildi (daha iyi: |{f_prime_fixed:.6f}| <= |{f_prime_normal:.6f}|)")
        else:
            print("Hata: Her iki yöntem de geçerli bir aday üretemedi!")
            break

        print(f"Sonraki x (x_{i + 2}) = {chosen_x:.6f}\n")

        # Değerleri bir sonraki iterasyon için güncelle
        # 'Normal Sekant' yönteminin bir sonraki adımda doğru çalışması için
        # x_prev'in güncellenmesi gerekir.
        x_prev = x_curr
        x_curr = chosen_x

    print(f"=== Sonuç ===\nOptimal nokta yaklaşık olarak: {x_curr:.6f}")


if __name__ == "__main__":
    funct_str = "x**3 - 3*x**2"
    start0 = 1.5  # x_0 (aynı zamanda sabit çapa)
    start1 = 3.0  # x_1
    iteration = 5

    hybrid_secant_method(start0, start1, funct_str, iteration)