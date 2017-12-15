#include "equipaje.h"

maleta::maleta(int id_)
{
    this->anterior = nullptr;
    this->siguiente = nullptr;
    this->id = id_;
}

equipaje::equipaje()
{
    this->cont = 1;
    this->cabeza = nullptr;
}

void equipaje::push()
{
    maleta *nuevo = new maleta(this->cont);
    //insertar cuando la lista está vacía
    if(this->cabeza == nullptr)
    {
        this->cabeza = nuevo;
        nuevo->siguiente = cabeza;
        nuevo->anterior = cabeza;
    }
    //insertar al final
    else
    {
        nuevo->anterior = this->cabeza->anterior;
        nuevo->anterior->siguiente = nuevo;
        this->cabeza->anterior = nuevo;
        nuevo->siguiente = this->cabeza;
    }
    this->cont++;
}

void equipaje::pop()
{
    maleta *temp = this->cabeza;
    if(temp != nullptr)
    {
        if(temp->siguiente == temp)
        {
            this->cabeza = nullptr;
        }
        else
        {
            this->cabeza->anterior->siguiente = this->cabeza->siguiente;
            this->cabeza->siguiente->anterior = this->cabeza->anterior;
            this->cabeza = this->cabeza->siguiente;
        }
    }
}
