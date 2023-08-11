using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookUpTable<T1, T2>
{
    //Creamos un delegate que tome un T1 como parametro,y devolvemos un T2,esto nos deja agregar cualquier funcion que tome un valor y devuelva otro
    public delegate T2 FactoryMethod(T1 keyToReturn);

    //Creamos una variable del tipo FactoryMethod para guardar una referencia a la funcion que crea el valor,cuando no lo tenemos guardado en la Table
    
    FactoryMethod _factoryMethod;

    //System.Func<T1, T2> _ecuacion;

    //Creamos un diccionario que use el tipo T1 como llave y T2 sea el valor que guarda.
    
    Dictionary<T1, T2> _table;
    

    //Constructor en donde vamos a guardar la funcion que crea dicho valor si no lo tenemos,en la variable
    
    public LookUpTable(FactoryMethod newFactory)
    {
        _factoryMethod = newFactory;
        _table = new Dictionary<T1, T2>();
    }

    //Funcion principal donde me pasan T1 para ver si esta en el diccionario,
    //si lo tengo devuelvo el valor,si no es asi, lo creo,lo guardo y lo devuelvo
    
    public T2 ReturnValue(T1 key)
    {
        if (_table.ContainsKey(key))
        {
            
            return _table[key];
        }

        

        //lo creo
        var value = _factoryMethod(key);

        //lo guardo
        _table[key] = value;
        //_table.Add(key, value);

        //lo devuelvo
        return value;

    }

}
