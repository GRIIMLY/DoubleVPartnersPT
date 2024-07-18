import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {


  public visibleModal: boolean = false;

  constructor() {

  }

  public showDialog() {
    this.visibleModal = true;
  }
}
