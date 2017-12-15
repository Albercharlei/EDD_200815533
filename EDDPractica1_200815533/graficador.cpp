#include "graficador.h"

#include <avion.h>

#include <QFile>
#include <QTextStream>
#include <string>

graficador::graficador()
{

}

QString graficador::graficar(pista *pista_, desabordaje *desabordaje_, escritorios *escritorios_)
{
    QString salida = "digraph G{\n";
    //agregar subgrafo de la pista
    salida += graficarpista(pista_);
    //agregar subgrafo del desabordaje
    salida += graficardesabordaje(desabordaje_);
    //agregar subgrafo de escritorios
    salida += graficarescritorios(escritorios_);
    //finalizar grafo
    salida += "}\n";
    //generar grafo
    QFile archivo("/Volumes/Macintosh HD/Users/charlei/Desktop/pista.dot");
        if(archivo.open(QFile::WriteOnly)){
            QTextStream st(&archivo);
            st << salida;
        }
    archivo.close();
    return salida;
}

QString graficador::graficarpista(pista *pista_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Pista{\ngraph[color=black, label=\"Pista\"];\n";
    salida += "node[shape=ellipse, color=black];\nrankdir=UD;\n";

    avion *temp = pista_->primero;
    //agregar identificadores
    while(temp != nullptr)
    {
        salida += "A" + QString::number(temp->cont) + " [label=\"Avión: " + QString::number(temp->cont) + "\nTipo: " + temp->tipostring + "\nPasajeros: " + QString::number(temp->pasajero) + "\"];\n";
        temp = temp->siguiente;
    }
    //agregar apuntadores
    temp = pista_->primero;
    if(temp != nullptr)
    {
        while(temp->siguiente != nullptr)
        {
            salida += "A" + QString::number(temp->cont) + "->" + "A" + QString::number(temp->siguiente->cont) + ";\n";
            salida += "A" + QString::number(temp->siguiente->cont) + "->" + "A" + QString::number(temp->cont) + ";\n";
            temp = temp->siguiente;
        }
    }
    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}

QString graficador::graficardesabordaje(desabordaje *desabordaje_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Desabordaje{\ngraph[color=black, label=\"Desabordaje\"];\n";
    salida += "node[shape=ellipse, color=black];\nrankdir=UD;\n";

    pasajero *temp = desabordaje_->primero;
    //agregar identificadores
    while(temp != nullptr)
    {
        salida += "P" + QString::number(temp->id) + " [label=\"ID: " + QString::number(temp->id) + "\nMaletas: " + QString::number(temp->maletas) + "\nDocumentos: " + QString::number(temp->documentos) + "\"];\n";
        temp = temp->siguiente;
    }
    //agregar apuntadores
    temp = desabordaje_->primero;
    if(temp != nullptr)
    {
        while(temp->siguiente != nullptr)
        {
            salida += "P" + QString::number(temp->id) + "->" + "P" + QString::number(temp->siguiente->id) + ";\n";
            temp = temp->siguiente;
        }
    }
    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}

QString graficador::graficarescritorios(escritorios *escritorios_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Escritorios{\ngraph[color=black, label=\"Escritorios\"];\n";
    salida += "node[shape=ellipse, color=black];\nrankdir=UD;\n";

    escritorio *temp = escritorios_->primero;

    //agregar identificadores
    while(temp != nullptr)
    {
        salida += "E" + temp->letra + " [label=\"Escritorio: " + temp->letra + "\nDocumentos: " + QString::number(temp->docs) + "\",shape=box,rank=min];\n";
        temp = temp->siguiente;
    }
    //agregar apuntadores
    temp = escritorios_->primero;
    if(temp != nullptr)
    {
        while(temp->siguiente != nullptr)
        {
            salida += "E" + temp->letra + "->" + "E" + temp->siguiente->letra + ";\n";
            salida += "E" + temp->siguiente->letra + "->" + "E" + temp->letra + ";\n";
            if(temp->cola->primero != nullptr) salida += graficarpasajeros(temp->cola,temp);
            if(temp->pila->tope != nullptr) salida += graficardocumentos(temp->pila,temp);
            temp = temp->siguiente;
        }
        if(temp->cola->primero != nullptr) salida += graficarpasajeros(temp->cola,temp);
        if(temp->pila->tope != nullptr) salida += graficardocumentos(temp->pila,temp);
    }

    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}

QString graficador::graficarpasajeros(colapasajeros *cola_,escritorio *escritorio_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Cola" + escritorio_->letra + "{\ngraph[color=black, label=\"Cola" + escritorio_->letra + "\"];\n";
    salida += "node[shape=ellipse, color=black];\nrankdir=UD;\n";

    pasajero *temp = cola_->primero;
    //agregar identificadores
    while(temp != nullptr)
    {
        salida += "CE" + QString::number(temp->id) + " [label=\"ID: " + QString::number(temp->id) + "\nDocumentos: " + QString::number(temp->documentos) + "\nTurnos: " + QString::number(temp->turnos) + "\"];\n";
        temp = temp->siguiente;
    }
    //agregar apuntadores
    temp = cola_->primero;
    if(temp != nullptr)
    {
        salida += "E" + escritorio_->letra + "->" + "CE" + QString::number(temp->id) + ";\n";
        while(temp->siguiente != nullptr)
        {
            salida += "CE" + QString::number(temp->id) + "->" + "CE" + QString::number(temp->siguiente->id) + ";\n";
            temp = temp->siguiente;
        }
    }
    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}

QString graficador::graficardocumentos(piladocumentos *pila_, escritorio *escritorio_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Pila" + escritorio_->letra + "{\ngraph[color=black, label=\"Pila" + escritorio_->letra + "\"];\n";
    salida += "node[shape=ellipse, color=black];\nrankdir=UD;\n";

    documento *temp = pila_->tope;
    //agregar identificadores
    while(temp != nullptr)
    {
        salida += "PE" + escritorio_->letra + temp->id + " [label=\"ID: " + temp->id + "\"];\n";
        temp = temp->anterior;
    }
    //agregar apuntadores
    temp = pila_->tope;
    if(temp != nullptr)
    {
        salida += "E" + escritorio_->letra + "->" + "PE" + escritorio_->letra + temp->id + ";\n";
        while(temp->anterior != nullptr)
        {
            salida += "PE" + escritorio_->letra + temp->id + "->" + "PE" + escritorio_->letra + temp->anterior->id + ";\n";
            temp = temp->anterior;
        }
    }
    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}
