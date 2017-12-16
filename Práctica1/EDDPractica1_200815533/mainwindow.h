#ifndef MAINWINDOW_H
#define MAINWINDOW_H

#include <avion.h>
#include <pasajero.h>
//#include <piladocumentos.h>
//#include <colapasajeros.h>
#include <escritorios.h>
#include <equipaje.h>
#include <mantenimiento.h>

#include <graficador.h>

#include <QMainWindow>

namespace Ui {
class MainWindow;
}

class MainWindow : public QMainWindow
{
    Q_OBJECT

public:
    //estructuras
    pista *mainpista;
    desabordaje *maindesabordaje;
    escritorios *mainescritorios;
    equipaje *mainequipaje;
    mantenimiento *mainmantenimiento;
    QString textoconsola;//texto de consola
    int turno;//contador de turnos
    explicit MainWindow(QWidget *parent = 0);
    ~MainWindow();

private slots:
    void on_pushButton_clicked();

private:
    Ui::MainWindow *ui;
};

#endif // MAINWINDOW_H
