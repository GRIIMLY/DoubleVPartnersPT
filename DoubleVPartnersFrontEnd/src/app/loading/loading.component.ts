import { Component, OnInit } from "@angular/core";

@Component({
  selector: "app-loading",
  templateUrl: "./loading.component.html",
  styleUrls: ["./loading.component.scss"],
})
export class LoadingComponent implements OnInit {
  /**
   * @property propiedad encargada de configurar el logo de carga
   */
  public loader = {
    type: "pulsing",
    themeColor: "primary",
    size: "medium",
  };

  constructor() {}

  ngOnInit(): void {}
}
