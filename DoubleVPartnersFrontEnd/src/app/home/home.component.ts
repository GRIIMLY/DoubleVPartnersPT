import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {


  public visibleModal: boolean = false;
  public visibleModalBD: boolean = false;


  public mostrarFormlogin: boolean = false;

  constructor() {

  }

  public showDialog(mostrarFormlogin: boolean) {
    this.visibleModal = true;
    this.mostrarFormlogin = mostrarFormlogin;
  }
}
