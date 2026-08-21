using System;
using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography;
// Ejercicios Pendientes
/*
- Agregar una canción al inicio. (ya)
- Agregar una canción al final. (ya)
- Insertar una canción después de otra canción específica. (ya)
- Buscar una canción por título. (ya)
- Buscar todas las canciones de un artista. (ya)
- Modificar la información de una canción. (ya)
- Eliminar una canción por título. (ya)
- Mostrar la lista de reproducción completa. (ya)
- Calcular la duración total de la lista. (ya)
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

        Console.WriteLine();

        // Le agregué un menu para no tener que estar cambiando el codigo cada vez que quiero probar algo
        int opcion = -1;
        while(opcion != 0)
        {
        Console.WriteLine();
        Console.WriteLine("1. Agregar cancion al inicio");
        Console.WriteLine("2. Agregar cancion al final");
        Console.WriteLine("3. Insertar cancion despues de otra");
        Console.WriteLine("4. Buscar cancion por titulo");
        Console.WriteLine("5. Buscar canciones de un artista");
        Console.WriteLine("6. Modificar una cancion");
        Console.WriteLine("7. Eliminar cancion por titulo");
        Console.WriteLine("8. Mostrar toda la lista");
        Console.WriteLine("9. Duracion total");
        Console.WriteLine("0. Salir");
        Console.Write("Opcion: ");
        opcion = Convert.ToInt32(Console.ReadLine());

        if(opcion == 1)
        {
            Console.Write("Titulo: ");
            string t = Console.ReadLine();
            Console.Write("Artista: ");
            string a = Console.ReadLine();
            Console.Write("Album: ");
            string al = Console.ReadLine();
            Console.Write("Duracion en segundos: ");
            int d = Convert.ToInt32(Console.ReadLine());
            lista.agregar_cancion_inicio(new Cancion(t, a, al, d));
        }
        else if(opcion == 2)
        {
            Console.Write("Titulo: ");
            string t = Console.ReadLine();
            Console.Write("Artista: ");
            string a = Console.ReadLine();
            Console.Write("Album: ");
            string al = Console.ReadLine();
            Console.Write("Duracion en segundos: ");
            int d = Convert.ToInt32(Console.ReadLine());
            lista.agregar_cancion_final(new Cancion(t, a, al, d));
        }
        else if(opcion == 3)
        {
            Console.Write("Despues de que cancion la insertas?: ");
            string referencia = Console.ReadLine();
            Console.Write("Titulo nueva cancion: ");
            string t = Console.ReadLine();
            Console.Write("Artista: ");
            string a = Console.ReadLine();
            Console.Write("Album: ");
            string al = Console.ReadLine();
            Console.Write("Duracion en segundos: ");
            int d = Convert.ToInt32(Console.ReadLine());
            lista.insertar_cancion_despues(referencia, new Cancion(t, a, al, d));
        }
        else if(opcion == 4)
        {
            Console.Write("Titulo a buscar: ");
            lista.buscar_cancion_titulo(Console.ReadLine());
        }
        else if(opcion == 5)
        {
            Console.Write("Artista a buscar: ");
            lista.buscar_cancion_artista(Console.ReadLine());
        }
        else if(opcion == 6)
        {
            Console.Write("Cual cancion queres modificar (titulo actual): ");
            string buscada = Console.ReadLine();
            Console.Write("Nuevo titulo: ");
            string t = Console.ReadLine();
            Console.Write("Nuevo artista: ");
            string a = Console.ReadLine();
            Console.Write("Nuevo album: ");
            string al = Console.ReadLine();
            Console.Write("Nueva duracion en segundos: ");
            int d = Convert.ToInt32(Console.ReadLine());
            lista.modificar_cancion(buscada, t, a, al, d);
        }
        else if(opcion == 7)
        {
            Console.Write("Titulo a eliminar: ");
            lista.eliminar_cancion_titulo(Console.ReadLine());
        }
        else if(opcion == 8)
        {
            lista.mostrar_lista();
        }
        else if(opcion == 9)
        {
            lista.calcular_duracion_total();
        }
        else if(opcion != 0)
        {
            Console.WriteLine("esa opcion no existe");
        }

        }
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

    // setters para poder modificar una cancion que ya existe en la lista
    public void setTitulo(string t)
    {
        titulo = t;
    }
    public void setArtista(string a)
    {
        artista = a;
    }
    public void setAlbum(string al)
    {
        album = al;
    }
    public void setDuracion(int d)
    {
        duracion = d;
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

    // Para insertar despues de una cancion especifica primero hay que encontrarla, entonces recorremos igual que en las busquedas
    public void insertar_cancion_despues(string tituloReferencia, Cancion nuevaCancion)
    {
        NodoCancion temp = head;

        while(temp != null)
        {
            if(temp.getCancion().getTitulo() == tituloReferencia)
            {
                NodoCancion nuevoNodo = new NodoCancion(nuevaCancion);
                nuevoNodo.setSiguiente(temp.getSiguiente()); // el nuevo nodo tiene que apuntar a lo que seguia antes
                temp.setSiguiente(nuevoNodo);
                tamanio++;
                Console.WriteLine("Se inserto la cancion despues de " + tituloReferencia);
                return;
            }
            temp = temp.getSiguiente();
        }

        Console.WriteLine("ERROR! no se encontro la cancion de referencia: " + tituloReferencia);
    }

    public void modificar_cancion(string tituloBuscado, string nuevoTitulo, string nuevoArtista, string nuevoAlbum, int nuevaDuracion)
    {
        NodoCancion temp = head;

        while(temp != null)
        {
            if(temp.getCancion().getTitulo() == tituloBuscado)
            {
                // aca ya encontramos el nodo, solo hace falta usar los setters de Cancion
                temp.getCancion().setTitulo(nuevoTitulo);
                temp.getCancion().setArtista(nuevoArtista);
                temp.getCancion().setAlbum(nuevoAlbum);
                temp.getCancion().setDuracion(nuevaDuracion);
                Console.WriteLine("Cancion modificada");
                return;
            }
            temp = temp.getSiguiente();
        }

        Console.WriteLine("ERROR! no se encontro esa cancion: " + tituloBuscado);
    }

    // Eliminar es un poco mas complicado porque hay que acordarse del nodo anterior para "saltarlo"
    public void eliminar_cancion_titulo(string titulo)
    {
        if(head == null)
        {
            Console.WriteLine("la lista esta vacia");
            return;
        }

        if(head.getCancion().getTitulo() == titulo)
        {
            head = head.getSiguiente();
            tamanio--;
            Console.WriteLine("cancion eliminada: " + titulo);
            return;
        }

        NodoCancion anterior = head;
        NodoCancion actual = head.getSiguiente();

        while(actual != null)
        {
            if(actual.getCancion().getTitulo() == titulo)
            {
                anterior.setSiguiente(actual.getSiguiente());
                tamanio--;
                Console.WriteLine("cancion eliminada: " + titulo);
                return;
            }
            anterior = actual;
            actual = actual.getSiguiente();
        }

        Console.WriteLine("ERROR! no se encontro la cancion " + titulo);
    }

    public void mostrar_lista()
    {
        if(head == null)
        {
            Console.WriteLine("la lista esta vacia");
            return;
        }

        NodoCancion temp = head;
        int i = 1;
        while(temp != null)
        {
            Console.WriteLine(i + "- " + temp.getCancion().getTitulo() + " / " + temp.getCancion().getArtista() + " / " + temp.getCancion().getAlbum() + " / " + temp.getCancion().getDuracion() + "s");
            temp = temp.getSiguiente();
            i++;
        }
    }

    public void calcular_duracion_total()
    {
        NodoCancion temp = head;
        int total = 0;

        while(temp != null)
        {
            total = total + temp.getCancion().getDuracion();
            temp = temp.getSiguiente();
        }

        Console.WriteLine("duracion total: " + total + " segundos (" + (total / 60) + " min con " + (total % 60) + " seg)");
    }

}