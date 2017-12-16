#ifndef PASAJERO_H
#define PASAJERO_H

#include <QString>

typedef struct pasajero pasajero;
typedef struct desabordaje desabordaje;

struct pasajero
{
    int id;//id generado correlativamente, empieza en 1
    int maletas;//cantidad de maletas aleatorias
    int documentos;//cantidad de documentos del pasajero
    int turnos;//cantidad de turnos en el registro
    int entregado;//entrega de documentos

    pasajero *siguiente;
    pasajero(int id_);
};

struct desabordaje//cola simple
{
    int cont;//contador de pasajeros para asignar id
    pasajero *primero;
    pasajero *ultimo;

    void push();
    pasajero *pop();
    desabordaje();
};

#endif // PASAJERO_H
