#include "mainwindow.h"
#include "ui_mainwindow.h"

MainWindow::MainWindow(QWidget *parent) :
    QMainWindow(parent),
    ui(new Ui::MainWindow)
{
    if(this->mainpista == nullptr) this->mainpista = new pista();
    if(this->maindesabordaje == nullptr) this->maindesabordaje = new desabordaje();
    ui->setupUi(this);
}

MainWindow::~MainWindow()
{
    delete ui;
}
//botón de acción
void MainWindow::on_pushButton_clicked()
{
    this->mainpista->push();
    //eliminar el primer avión si se terminaron sus turnos de desbordaje
    if(this->mainpista->primero->desabordaje == 0) this->mainpista->pop();
    else this->mainpista->primero->desabordaje--;
    //insertar la cantidad de pasajeros de un avión
    if(this->mainpista->primero != nullptr)
    {
        for(int i = 0;i<this->mainpista->primero->pasajero;i++) this->maindesabordaje->push();
        this->mainpista->primero->pasajero = 0;
    }
    graficador *graph = new graficador();
    graph->graficar(mainpista,maindesabordaje);
}
