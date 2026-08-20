using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
// Ejercicios Pendientes
/*
- Agregar una canción al inicio. (ya)
- Agregar una canción al final. (ya)
- Insertar una canción después de otra canción específica.
- Buscar una canción por título. (ya)
- Buscar todas las canciones de un artista. (ya)
- Modificar la información de una canción.
- Eliminar una canción por título.
- Mostrar la lista de reproducción completa.
- Calcular la duración total de la lista.
*/
public class Tarea 
{
    public static void Main()
    {
        Cancion cancion1 = new Cancion(
            "Drive",
            "Incubus",
            "Make Yourself",
            232
        );

        Cancion cancion2 = new Cancion(
            "Wish You Were Here",
            "Pink Floyd",
            "Wish You Were Here",
            334
        );

        Cancion cancion3 = new Cancion(
            "Yellow",
            "Coldplay",
            "Parachutes",
            266
        );

        Cancion cancion4 = new Cancion(
            "Anna Molly",
            "Incubus",
            "Light Grenades",
            226
        );


        ListaReproduccion lista = new ListaReproduccion();

        lista.agregar_cancion_final(cancion1);
        lista.agregar_cancion_final(cancion2);
        lista.agregar_cancion_final(cancion3);
        lista.agregar_cancion_final(cancion4);

        Console.WriteLine("=== BUSCAR POR TITULO ===");

        lista.buscar_cancion_titulo("Yellow");

        Console.WriteLine();

        Console.WriteLine("=== BUSCAR POR ARTISTA ===");

        lista.buscar_cancion_artista("Incubus");
    }
}

public class Cancion
{
    private string titulo;
    private string artista;
    private string album;
    private int duracion;   
    
    public Cancion(string newTitulo, string newArtista, string newAlbum, int newDuracion)
    {
        titulo = newTitulo;
        artista = newArtista;
        album = newAlbum;
        duracion = newDuracion;
    }

    // Para mantener el encapsulamiento, se usan getters, asi los atributos pueden ser privados y "usarse en otras clases"
       public string getTitulo()
    {
        return titulo;
    }

    public string getArtista()
    {
        return artista;
    }

    public string getAlbum()
    {
        return album;
    }

    public int getDuracion()
    {
        return duracion;
    }

}
public class NodoCancion
{
    private Cancion cancion;
    private NodoCancion siguiente; //Guarda el siguiente objeto de NodoCancion, es decir la siguiente referencia

    public NodoCancion(Cancion newCancion) // Constructor 
    {
        cancion = newCancion;
        siguiente = null;
    }

       public Cancion getCancion()
    {
        return cancion;
    }

    public NodoCancion getSiguiente()
    {
        return siguiente;
    }
    // Igual se ocupa un setter para mantener el encapsulamiento
    public void setSiguiente(NodoCancion nuevoSiguiente)
    {
        siguiente = nuevoSiguiente;
    }
}


public class ListaReproduccion
{
private NodoCancion head;
private NodoCancion tail; // Cola
private int tamanio;
public ListaReproduccion()
    {
        head = null;
        tail = null;
        tamanio = 0; 
    } // Constructor de la lista 


public void agregar_cancion_final(Cancion cancion)
{
    NodoCancion newNodo = new NodoCancion(cancion);
    if (head == null)
    {
        // La lista está vacía
        head = newNodo;
    }
    else // Si head existe
    {
        NodoCancion temp = head; //Creamos un objeto NodoCacion temporal head
        while (temp.getSiguiente() != null)
        {
            temp = temp.getSiguiente(); //obtiene cual va a ser el siguiente nodo o "cancion" para mover la lista
        }

        temp.setSiguiente(newNodo); //Ya al finalizar el loop, podemos settear el valor del siguiente a temp
    }
    tamanio++;
}
public void agregar_cancion_inicio(Cancion cancion)
{
    NodoCancion newHead = new NodoCancion(cancion); //Creamos la nueva cabeza de la lista
    if(head == null)
    {
        // La lista está vacía
        head = newHead;
        tamanio++;
    } else {
    newHead.setSiguiente(head); // a la nueva cabeza se le guarda como siguiente "cancion" la vieja cabeza
    head = newHead; // la nueva cabeza reemplaza a la vieja.
    tamanio++;
    }
}

public void buscar_cancion_titulo(string titulo)
    {
        NodoCancion temp = head;

        while(temp != null)
        {
         if(temp.getCancion().getTitulo() == titulo) // En el objeto nodo, guardamos el objeto cancion como una variable, entonces primero "sacamos" la cancion y luego le sacamos el titulo
            {
                Console.WriteLine("Busqueda por nombre exitosa!, Cancion: " + temp.getCancion().getTitulo()); 
                return;
            } 
                temp = temp.getSiguiente();
        }
        
        Console.WriteLine("ERROR! No se encontro la canción: " + titulo + "en la lista de reproducción");
    }
public void buscar_cancion_artista(string artista)
    {
        NodoCancion temp = head;
        bool artista_encontrado = false;

        while(temp != null)
        {
         if(temp.getCancion().getArtista() == artista) // En el objeto nodo, guardamos el objeto cancion como una variable, entonces primero "sacamos" la cancion y luego le sacamos el titulo
            {
                Console.WriteLine("Canción del artista: "+ artista + "encontrada!: " + temp.getCancion().getTitulo()); 
                artista_encontrado = true; // Si encontro una cancion del artista
            } 
                temp = temp.getSiguiente();
        }
        
        if(artista_encontrado == false)
        {
            Console.WriteLine("ERROR! No se encontro ninguna canción del: " + artista + "en la lista de reproducción");
        }

    }

}



  