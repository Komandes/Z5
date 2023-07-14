using System;

public class Program
{
    public static void Main()
    {
        Macierz<int> macierz = new Macierz<int>(3, 3);
        macierz[0, 0] = 1;
        macierz[0, 1] = 2;
        macierz[0, 2] = 3;
        macierz[1, 0] = 4;
        macierz[1, 1] = 5;
        macierz[1, 2] = 6;
        macierz[2, 0] = 7;
        macierz[2, 1] = 8;
        macierz[2, 2] = 9;

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(macierz[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

public class Macierz<T> : IEquatable<Macierz<T>>
{
    private readonly T[,] komórki;

    public Macierz(int wiersze, int kolumny)
    {
        if (wiersze <= 0 || kolumny <= 0)
            throw new ArgumentException("Wymiary macierzy muszą być większe od zera.");

        komórki = new T[wiersze, kolumny];
    }

     public T this[int wiersz, int kolumna]
     {
         get => komórki[wiersz, kolumna];
         set => komórki[wiersz, kolumna] = value;
     }

      public bool Equals(Macierz<T> innaMacierz)
      {
          if (innaMacierz == null)
              return false;

           if (ReferenceEquals(this, innaMacierz))
              return true;
    
          if (komórki.GetLength(0) != innaMacierz.komórki.GetLength(0) || komórki.GetLength(1) != innaMacierz.komórki.GetLength(1))
             return false;
    
         for (int i = 0; i < komórki.GetLength(0); i++)
         {
             for (int j = 0; j < komórki.GetLength(1); j++)
              {
                  if (!Equals(komórki[i, j], innaMacierz.komórki[i, j]))
                     return false;
              }
           }

           return true;
       }

       public override bool Equals(object obj)
       {
          if (obj is Macierz<T> innaMacierz)
              return Equals(innaMacierz);

            return false;
      }

      public override int GetHashCode()
      {
          unchecked
          {
              int hash = 17;
                hash = hash * 23 + komórki.GetLength(0).GetHashCode();
                hash = hash * 23 + komórki.GetLength(1).GetHashCode();
                return hash;
            }   
        }

     public static bool operator ==(Macierz<T> m1, Macierz<T> m2)
        {
            if (ReferenceEquals(m1, m2))
                return true;

            if (m1 is null || m2 is null)
                return false;

            return m1.Equals(m2);
        }

        public static bool operator !=(Macierz<T> m1, Macierz<T> m2)
     {
         return !(m1 == m2);
     }
}

