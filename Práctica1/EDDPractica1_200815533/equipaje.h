#ifndef EQUIPAJE_H
#define EQUIPAJE_H
#include <QString>

typedef struct maleta maleta;
typedef struct equipaje equipaje;

struct maleta
{
    int id;
    maleta *siguiente;
    maleta *anterior;

    maleta(int id_);
};

struct equipaje
{
    int cont;
    maleta *cabeza;

    void push();
    void pop();
    equipaje();
    QString salidaconsola();
};

#endif // EQUIPAJE_H
