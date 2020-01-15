import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weather-api',
  templateUrl: './weather-api.component.html',
  styleUrls: ['./weather-api.component.css']
})
export class WeatherApiComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  icaoCode: string;
  onSubmit() {
    console.log(this.icaoCode);
  }
}
