#ifndef AVION_H
#define AVION_H
#include <QString>

typedef struct avion avion;
typedef struct pista pista;

struct avion
{
    int pasajero;//cantidad de pasajeros en el avión
    int desabordaje;//cantidad de turnos en el aeropuerto durante el desbordaje
    int mantenimiento;//cantidad de turnos en las estaciones de mantenimiento
    int tipo;//1: pequeño, 2: mediano, 3: grande
    int cont;//contador de aviones agregados
    QString tipostring;//tipo de avión
    avion *siguiente;
    avion *anterior;

    avion();//constructor
};

struct pista
{
    avion *primero;
    avion *ultimo;

    void push();
    avion *pop();
};

#endif // AVION_H
