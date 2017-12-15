#include "escritorios.h"

escritorio::escritorio(QString letra_)
{
    this->anterior = nullptr;
    this->siguiente = nullptr;
    this->cola = new colapasajeros();
    this->pila = new piladocumentos();
    this->letra = letra_;
    this->docs = 0;
}

void escritorio::insertarpasajero(pasajero *pasajero_)
{
    if(this->cola == nullptr) this->cola = new colapasajeros();
    if(this->pila == nullptr) this->pila = new piladocumentos();
    //insertar el pasajero
    this->cola->push(pasajero_);
    //insertar los documentos del primer pasajero
    for(int i=0;i < this->cola->primero->documentos;i++)
    {
        this->pila->push();
    }
    //no insertar si el primer pasajero de la cola no tiene documentos
    if(this->cola->primero->documentos != 0)
    {
        this->docs = this->cola->primero->documentos;
        this->cola->primero->documentos = 0;
    }
}

void escritorio::pop()
{
    if(this->cola != nullptr)
    {
        if(this->cola->primero != nullptr)
        {
            //eliminar si el pasajero ya no tiene turnos
            if(this->cola->primero->turnos == 0)
            {
                this->cola->pop();
                this->pila->vaciar();
                //insertar los documentos del primer pasajero
                for(int i=0;i < this->cola->primero->documentos;i++)
                {
                    this->pila->push();
                }
                //no insertar si el primer pasajero de la cola no tiene documentos
                if(this->cola->primero->documentos != 0)
                {
                    this->docs = this->cola->primero->documentos;
                    this->cola->primero->documentos = 0;
                }
            }
            //reducir la cantidad de turnos
            else this->cola->primero->turnos--;
        }
    }
}

escritorios::escritorios()
{
    this->actual = nullptr;
    this->primero = nullptr;
}

void escritorios::insertarescritorio(QString letra_)
{
    escritorio *nuevo = new escritorio(letra_);
    //insertar si está vacío
    if(this->primero == nullptr) this->primero = nuevo;
    //insertar de forma ordenada
    else
    {
        escritorio *temp = this->primero;
        //insertar al inicio
        if(temp->letra > nuevo->letra)
        {
            nuevo->siguiente = temp;
            this->primero->anterior = temp;
            this->primero = nuevo;
        }
        else
        {
            //insertar al medio
            while(temp->siguiente != nullptr)
            {
                //insertar antes del nodo temp
                if(temp->siguiente->letra > nuevo->letra)
                {
                    temp->siguiente->anterior = nuevo;
                    nuevo->siguiente = temp->siguiente;
                    temp->siguiente = nuevo;
                    nuevo->anterior = temp;
                    return;
                }
                else temp = temp->siguiente;
            }
            //insertar al final
            temp->siguiente = nuevo;
            nuevo->anterior = temp;
        }

    }
}

escritorio *escritorios::getcola()
{
    //establecer el escritorio actual
    if(this->actual == nullptr) this->actual = this->primero;
    while(this->actual != nullptr)
    {
        if(this->actual->cola->cont < 10)
        {//hay espacio para la inserción
            //obtener el escritorio de inserción
            escritorio *ret = this->actual;
            //establecer el nuevo escritorio
            this->actual = this->actual->siguiente;
            return ret;
        }
        //no hay espacio para inserción
        else this->actual = this->actual->siguiente;
    }
    return nullptr;
}

void escritorios::eliminarpasajeros()
{
    escritorio *temp = this->primero;
    while(temp != nullptr)
    {
        temp->pop();//eliminar pasajero si ya no tiene turnos
        temp = temp->siguiente;
    }
}
