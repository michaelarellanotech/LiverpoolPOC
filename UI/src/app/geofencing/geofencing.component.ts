import { Component, OnInit } from '@angular/core';
import { GeofencingService } from './geofencing.service';
import { AddressSearchResult } from './geofencing.model';


@Component({
  selector: 'app-geofencing',
  templateUrl: './geofencing.component.html',
  styleUrls: ['./geofencing.component.css']
})
export class GeofencingComponent implements OnInit {
  filteredAddress: AddressSearchResult[];
  geocodeAddress: AddressSearchResult = new AddressSearchResult();
  completedSearch: boolean = false;

  constructor(
    public geofencingService: GeofencingService,
    ) {}

  ngOnInit() {}

  filterAddress(event) {
    let query = event.query;
    
    this.geofencingService.addressSearch(query).subscribe(data => {
        this.filteredAddress = data;
        if (data.length == 0)
        {
          this.geocodeAddress = new AddressSearchResult();
        }
    });
  }

  onSelect(event: AddressSearchResult) {

    this.completedSearch = false;

    this.geofencingService.getGeocode(event.recordId, event.displayLine).subscribe((data:AddressSearchResult) => {
      
      this.geocodeAddress = new AddressSearchResult();

      
      if (data && data.isInWesternSydney) {

        this.geocodeAddress = data;
        
      } 

      this.completedSearch = true;
    });
  }
}
