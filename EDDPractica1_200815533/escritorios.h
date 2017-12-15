#ifndef ESCRITORIOS_H
#define ESCRITORIOS_H

#include <colapasajeros.h>
#include <piladocumentos.h>
#include <QString>

typedef struct escritorio escritorio;
typedef struct escritorios escritorios;

struct escritorio//escritorio de registro
{
    QString letra;//letra de identificación
    colapasajeros *cola;//cola de pasajeros
    piladocumentos *pila;//pila de documentos
    int docs;//contador de pasajeros
    escritorio *siguiente;
    escritorio *anterior;

    escritorio(QString letra_);
    void insertarpasajero(pasajero *pasajero_);
    void pop();//eliminar al pasajero que está primero
};

struct escritorios//lista ordenada
{
    escritorio *primero;
    escritorio *actual;//escritorio actual seleccionado

    escritorios();
    void insertarescritorio(QString letra_);
    //void insertarpasajero(pasajero *pasajero_);
    escritorio *getcola();
    void eliminarpasajeros();
};

#endif // ESCRITORIOS_H
