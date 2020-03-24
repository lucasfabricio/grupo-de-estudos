import { Component, OnInit } from '@angular/core';
import { Advertisement } from '../advertisement';
import { ADVERTISEMENTS } from '../mock-advertisements';

@Component({
  selector: 'app-advertisements',
  templateUrl: './advertisements.component.html',
  styleUrls: ['./advertisements.component.css']
})

export class AdvertisementsComponent implements OnInit {

  advertisements = ADVERTISEMENTS;
  selectedAdvertisement: Advertisement;

  constructor() { }

  ngOnInit() {
  }

  onSelect(advertisement: Advertisement): void {
    this.selectedAdvertisement = advertisement;
  }
}