#include "graficador.h"


#include <QFile>
#include <QTextStream>
#include <string>

graficador::graficador()
{

}

QString graficador::graficar(pista *pista_, desabordaje *desabordaje_, escritorios *escritorios_, equipaje *equipaje_, mantenimiento *mantenimiento_)
{
    QString salida = "digraph G{\ncluster=true;\n";
    //agregar subgrafo de la pista
    salida += graficarpista(pista_);
    //agregar subgrafo del desabordaje
    salida += graficardesabordaje(desabordaje_);
    //agregar subgrafo de escritorios
    salida += graficarescritorios(escritorios_);
    //agregar subgrafo de equipaje
    salida += graficarequipaje(equipaje_);
    //agregar subgrafo de mantenimiento
    salida += graficarmantenimiento(mantenimiento_);
    //finalizar grafo
    salida += "}\n";
    //generar grafo
    QFile archivo("/Volumes/Macintosh HD/Users/pista.dot");
    //QFile archivo("~/Contents/pista.dot");
    if(archivo.open(QFile::WriteOnly)){
        QTextStream st(&archivo);
        st << salida;
    }
    archivo.close();

    //system("cd /Volumes/Macintosh\ HD/Users/charlei/Desktop/");
    std::string ruta = "open " + archivo.fileName().toStdString();
    //system("cd /Volumes/Macintosh\\ HD/Users/");
    system("dot -Tjpeg -O /Volumes/Macintosh\\ HD/Users/pista.dot");
    system("open /Volumes/Macintosh\\ HD/Users/pista.dot");
    //system("rm /Volumes/Macintosh\\ HD/Users/pista.dot");
    return salida;
}

QString graficador::graficarpista(pista *pista_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Pista{\ngraph[color=black, label=\"Pista\"];\n";
    salida += "node[shape=ellipse, color=black];\nrankdir=TB;\n";

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
    salida += "node[shape=ellipse, color=black];\nrankdir=TB;\n";

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
    salida += "node[shape=ellipse, color=black];\nrankdir=LR;\n";

    escritorio *temp = escritorios_->primero;

    //agregar identificadores
    while(temp != nullptr)
    {
        if(temp->cola->primero != nullptr) salida += "E" + temp->letra + " [label=\"Escritorio: " + temp->letra + "\nEstado: Ocupado\nDocumentos: " + QString::number(temp->docs) + "\nTurnos restantes: " + QString::number(temp->turnos) + "\",shape=box,rank=min];\n";
        else salida += "E" + temp->letra + " [label=\"Escritorio: " + temp->letra + "\nEstado: Disponible\nDocumentos: " + QString::number(temp->docs) + "\nTurnos: 0" + "\",shape=box,rank=min];\n";
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
    salida += "node[shape=ellipse, color=black];\nrankdir=TB;\n";

    pasajero *temp = cola_->primero;
    //agregar identificadores
    while(temp != nullptr)
    {
        salida += "CE" + QString::number(temp->id) + " [label=\"ID: " + QString::number(temp->id) + "\nMaletas: " + QString::number(temp->maletas) + "\"];\n";
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
    salida += "node[shape=ellipse, color=black];\nrankdir=BT;\n";

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

QString graficador::graficarequipaje(equipaje *equipaje_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Equipaje{\ngraph[color=black, label=\"Equipaje\"];\n";
    salida += "node[shape=box, color=black];\n";

    maleta *temp = equipaje_->cabeza;
    //agregar identificadores
    if(temp != nullptr)
    {
        salida += "Maleta" + QString::number(temp->id) + " [label=\"Maleta " + QString::number(temp->id) + "\"];\n";
        temp = temp->siguiente;
        while(temp != equipaje_->cabeza)
        {
            salida += "Maleta" + QString::number(temp->id) + " [label=\"Maleta" + QString::number(temp->id) + "\"];\n";
            temp = temp->siguiente;
        }
    }
    //agregar apuntadores
    temp = equipaje_->cabeza;
    if(temp != nullptr)
    {
        salida += "Maleta" + QString::number(temp->id) + "->" + "Maleta" + QString::number(temp->siguiente->id) + ";\n";
        salida += "Maleta" + QString::number(temp->id) + "->" + "Maleta" + QString::number(temp->anterior->id) + ";\n";
        temp = temp->siguiente;
        while(temp != equipaje_->cabeza)
        {
            salida += "Maleta" + QString::number(temp->id) + "->" + "Maleta" + QString::number(temp->siguiente->id) + ";\n";
            salida += "Maleta" + QString::number(temp->id) + "->" + "Maleta" + QString::number(temp->anterior->id) + ";\n";
            temp = temp->siguiente;
        }
    }

    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}

QString graficador::graficarmantenimiento(mantenimiento *mant_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Mantenimiento{\ngraph[color=black, label=\"Mantenimiento\"];\n";
    salida += "node[shape=box, color=black];\nrankdir=LR;\n";

    estacion *temp = mant_->primero;
    //agregar identificadores
    if(temp != nullptr)
    {
        while(temp != nullptr)
        {
            if(temp->cola->primero != nullptr) salida += "Estacion" + QString::number(temp->id) + " [label=\"Estación " + QString::number(temp->id) + "\nTurnos restantes: " + QString::number(temp->cola->primero->mantenimiento) + "\"];\n";
            else salida += "Estacion" + QString::number(temp->id) + " [label=\"Estación " + QString::number(temp->id) + "\nTurnos restantes: 0\"];\n";
            temp = temp->siguiente;
        }
    }
    //agregar apuntadores
    temp = mant_->primero;
    if(temp != nullptr)
    {
        while(temp->siguiente != nullptr)
        {
            salida += "Estacion" + QString::number(temp->id) + "->" + "Estacion" + QString::number(temp->siguiente->id) + ";\n";
            if(temp->cola->primero != nullptr) salida += graficaraviones(temp->cola,temp);
            temp = temp->siguiente;
        }
        if(temp->cola->primero != nullptr) salida += graficaraviones(temp->cola,temp);
    }

    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}

QString graficador::graficaraviones(colaestacion *cola_,estacion *estacion_)
{
    QString salida = "";
    //iniciar sugrafo de la pista de aviones
    salida += "subgraph Colamantenimiento" + QString::number(estacion_->id) + "{\ngraph[color=black, label=\"Mantenimiento\"];\n";
    salida += "node[shape=box, color=black];\nrankdir=TB;\n";

    avion *temp = cola_->primero;
    if(temp != nullptr)
    {
        while(temp != nullptr)
        {
            salida += "ColaEstacion" + QString::number(estacion_->id) + QString::number(temp->cont) + " [label=\"Avión " + QString::number(temp->cont) + "\"];\n";
            temp = temp->siguiente;
        }
    }
    //agregar apuntadores
    temp = cola_->primero;
    if(temp != nullptr)
    {
        salida += "Estacion" + QString::number(temp->cont) + "->" + "ColaEstacion" + QString::number(estacion_->id) + QString::number(temp->cont) + ";\n";
        if(temp->siguiente != nullptr) salida += "ColaEstacion" + QString::number(estacion_->id) + QString::number(temp->cont) + "->" + "ColaEstacion" + QString::number(estacion_->id) + QString::number(temp->siguiente->cont) + ";\n";
        temp = temp->siguiente;
        if(temp != nullptr)
        {
            while(temp->siguiente != nullptr)
            {
                salida += "ColaEstacion" + QString::number(estacion_->id) + QString::number(temp->cont) + "->" + "ColaEstacion" + QString::number(estacion_->id) + QString::number(temp->siguiente->cont) + ";\n";
                temp = temp->siguiente;
            }
        }
    }

    //finalizar subgrafo de la pista
    salida += "}\n";

    return salida;
}
