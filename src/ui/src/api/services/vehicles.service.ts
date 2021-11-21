/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { GetVehiclesResponse } from '../models/get-vehicles-response';

@Injectable({
  providedIn: 'root',
})
export class VehiclesService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiVehiclesGet
   */
  static readonly ApiVehiclesGetPath = '/api/vehicles';

  /**
   * Gets a list of vehicles optionally filtered by fleet ID.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVehiclesGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVehiclesGet$Plain$Response(params?: {
    FleetId?: number;
  }): Observable<StrictHttpResponse<GetVehiclesResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VehiclesService.ApiVehiclesGetPath, 'get');
    if (params) {
      rb.query('FleetId', params.FleetId, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GetVehiclesResponse>;
      })
    );
  }

  /**
   * Gets a list of vehicles optionally filtered by fleet ID.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVehiclesGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVehiclesGet$Plain(params?: {
    FleetId?: number;
  }): Observable<GetVehiclesResponse> {

    return this.apiVehiclesGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<GetVehiclesResponse>) => r.body as GetVehiclesResponse)
    );
  }

  /**
   * Gets a list of vehicles optionally filtered by fleet ID.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiVehiclesGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVehiclesGet$Json$Response(params?: {
    FleetId?: number;
  }): Observable<StrictHttpResponse<GetVehiclesResponse>> {

    const rb = new RequestBuilder(this.rootUrl, VehiclesService.ApiVehiclesGetPath, 'get');
    if (params) {
      rb.query('FleetId', params.FleetId, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GetVehiclesResponse>;
      })
    );
  }

  /**
   * Gets a list of vehicles optionally filtered by fleet ID.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiVehiclesGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiVehiclesGet$Json(params?: {
    FleetId?: number;
  }): Observable<GetVehiclesResponse> {

    return this.apiVehiclesGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<GetVehiclesResponse>) => r.body as GetVehiclesResponse)
    );
  }

}
