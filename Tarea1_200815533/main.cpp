#include <QCoreApplication>
#include <cstdlib>
#include <iostream>

typedef struct nodo nodo;
typedef struct lista lista;

struct nodo
{
    int valor;
    nodo *siguiente;
    nodo *anterior;
};

struct lista
{
    nodo *primero;
    nodo *ultimo;
};

lista *nuevalista()
{
    lista *nueva = (lista*)malloc(sizeof(lista));
    nueva->primero = nullptr;
    nueva->ultimo = nullptr;
    return nueva;
}

nodo *nuevonodo(int valor_)
{
    nodo *nuevo = (nodo*)malloc(sizeof(nodo));
    nuevo->anterior = nullptr;
    nuevo->siguiente = nullptr;
    nuevo->valor = valor_;
    return nuevo;
}

void insertar(lista *lista_ , int valor_)
{
    nodo *nuevo = nuevonodo(valor_);
    if(lista_->primero == nullptr)
    {
        lista_->primero = nuevo;
        lista_->ultimo = nuevo;
    }
    else
    {
        lista_->ultimo->siguiente = nuevo;
        nuevo->anterior = lista_->ultimo;
        lista_->ultimo = nuevo;
    }
}

void eliminar(lista *lista_ , int valor_)
{
    nodo *temp = lista_->primero;
    while(temp != nullptr)
    {
        if(temp->valor == valor_)
        {
            if(temp->anterior != nullptr) temp->anterior->siguiente = temp->siguiente;
            if(temp->siguiente != nullptr) temp->siguiente->anterior = temp->anterior;
            if(temp == lista_->primero) lista_->primero = temp->siguiente;
            if(temp == lista_->ultimo) lista_->ultimo = temp->anterior;
            return;
        }
        else temp = temp->siguiente;
    }
    std::cout << "No se encontró el valor ingresado" << std::endl;
}

void mostrar(lista *lista_)
{
    nodo *temp = lista_->primero;
    if(temp != nullptr)
    {
        std::cout << temp->valor;
        temp = temp->siguiente;
        while(temp != nullptr)
        {
            std::cout << "->" << temp->valor;
            temp = temp->siguiente;
        }
        std::cout << std::endl;
        return;
    }
    std::cout << "No hay elementos en la lista" << std::endl;
}

void menu(lista *lista_)
{
    std::cout << "Seleccione una opción: " << std::endl;
    std::cout << "1. Insertar" << std::endl;
    std::cout << "2. Eliminar" << std::endl;
    std::cout << "3. Mostrar" << std::endl;
    int in = 0;
    std::cin >> in;
    //método de inserción
    if(in == 1)
    {
        std::cout << "Ingrese un número:" << std::endl;
        int ingreso = 0;
        std::cin >> ingreso;
        insertar(lista_,ingreso);
    }
    //método de eliminación
    else if(in == 2)
    {
        std::cout << "Ingrese un número:" << std::endl;
        int ingreso = 0;
        std::cin >> ingreso;
        eliminar(lista_,ingreso);
    }
    //mostrar la lista
    else if(in == 3)
    {
        mostrar(lista_);
    }
    else
    {
        std::cout << "No ha ingresado una opción válida" << std::endl;
    }
    menu(lista_);
}

int main(int argc, char *argv[])
{
    QCoreApplication a(argc, argv);
    lista *listado = nuevalista();
    menu(listado);

    return a.exec();
}
