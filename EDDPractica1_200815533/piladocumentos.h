#ifndef PILADOCUMENTOS_H
#define PILADOCUMENTOS_H

#include <qstring.h>

typedef struct documento documento;
typedef struct piladocumentos documentos;

struct documento
{
    documento *siguiente;
    documento *anterior;
    QString id;
    documento(int cont);
};

struct piladocumentos
{
    documento *tope;
    int cont;

    piladocumentos();
    void push();
    void vaciar();
};

#endif // PILADOCUMENTOS_H
