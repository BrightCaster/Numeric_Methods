import numpy as np
import array
import random as rn

def Obrt(S):
    S=np.linalg.inv(S)
    return S

def Spec(b):
    L,V= np.linalg.eigh(b)
    return V, L

def B(a):
    b=np.dot(np.transpose(a),a)
    return b

def main():
    size=rn.randint(7,7)
    a=[[rn.randint(0,9) for j in range(size)]for i in range(size)]
    b=B(a)
    V,L=Spec(b)
    V=np.fliplr(V)
    S=np.sqrt(L)
    s=np.diag(S)
    s=np.fliplr(s)
    s=np.flipud(s)
    S=Obrt(s)
    u=np.dot(np.dot(a,V),S)
    print("Разложение U:")
    print(u)
    print("Разложение S:")
    print(s)
    print("Разложение VT:")
    print(np.transpose(V))
    print("Проверка Встроенного алгоритма")
    U,E,K=np.linalg.svd(a)
    print(U)
    print(np.diag(E))
    print(K)

if __name__=='__main__':
    main()

