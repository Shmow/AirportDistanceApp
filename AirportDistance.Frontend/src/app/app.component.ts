import { Component, OnInit } from '@angular/core';
import { AirportRequest } from './models/airport-request';
import { AirportDataService } from './services/airport-data.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public model: AirportRequest;

  constructor(private airportDataService: AirportDataService) {  }

  ngOnInit(): void {
    this.model = new AirportRequest();
  }

  onSubmit(): void {
    this.airportDataService.getAirportData(this.model)
                           .subscribe(resp => console.log(resp));
  }
}
