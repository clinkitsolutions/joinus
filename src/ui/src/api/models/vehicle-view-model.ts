/* tslint:disable */
/* eslint-disable */
import { Location } from './location';
import { VehicleType } from './vehicle-type';
export interface VehicleViewModel {
  id?: number;
  lastKnownLocation?: Location;
  name?: null | string;
  type?: VehicleType;
}
