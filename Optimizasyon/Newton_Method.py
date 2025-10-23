import sympy as sp
import numpy as np


def newton_method_lambdify(start, funct_str, iteration):
    x = sp.Symbol('x')
    try:
        sym_f = sp.sympify(funct_str)
    except sp.SympifyError:
        print("Geçersiz fonksiyon girdisi!")
        return

    # 1. Sembolik türevleri al
    df_dx = sp.diff(sym_f, x)
    df_dx2 = sp.diff(df_dx, x)

    # 2. Döngüden ÖNCE türevleri sayısal fonksiyonlara çevir
    f_prime_num = sp.lambdify(x, df_dx, 'numpy')
    f_double_prime_num = sp.lambdify(x, df_dx2, 'numpy')

    current_x = float(start)

    print(f"Fonksiyon: {sym_f}")
    print(f"f'(x): {df_dx}")
    print(f"f''(x): {df_dx2}\n")

    for i in range(iteration):
        print(f"--- İterasyon {i} ---")
        print(f"Başlangıç x({i}) = {current_x:.6f}")

        # 3. Hazır fonksiyonları sayısal değerle çağır
        f_prime_val = f_prime_num(current_x)
        f_double_prime_val = f_double_prime_num(current_x)

        if f_double_prime_val == 0:
            print("Hata: İkinci türev sıfır oldu, bölme hatası!")
            break

        next_x = current_x - (f_prime_val / f_double_prime_val)

        print(f"f'({current_x:.4f}) = {f_prime_val}")
        print(f"f''({current_x:.4f}) = {f_double_prime_val}")
        print(f"Sonraki x({i + 1}) = {next_x:.6f}\n")

        current_x = next_x

    print(f"=== Sonuç ===\nOptimal nokta yaklaşık olarak: {current_x:.6f}")


if  __name__ == "_main_":
    start = float(input("Başlangıç noktası girin: "))
    funct_str = input("Fonksiyonu girin (örn: x*3 - 3*x*2): ")
    iteration = int(input("İterasyon sayısı girin: "))
    newton_method_lambdify(start, funct_str, iteration)
