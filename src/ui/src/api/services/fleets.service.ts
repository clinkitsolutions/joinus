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

import { GetFleetsRequest } from '../models/get-fleets-request';
import { GetFleetsResponse } from '../models/get-fleets-response';

@Injectable({
  providedIn: 'root',
})
export class FleetsService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiFleetsGet
   */
  static readonly ApiFleetsGetPath = '/api/fleets';

  /**
   * Gets a list of fleets.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFleetsGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFleetsGet$Plain$Response(params?: {
    request?: GetFleetsRequest;
  }): Observable<StrictHttpResponse<GetFleetsResponse>> {

    const rb = new RequestBuilder(this.rootUrl, FleetsService.ApiFleetsGetPath, 'get');
    if (params) {
      rb.query('request', params.request, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GetFleetsResponse>;
      })
    );
  }

  /**
   * Gets a list of fleets.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFleetsGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFleetsGet$Plain(params?: {
    request?: GetFleetsRequest;
  }): Observable<GetFleetsResponse> {

    return this.apiFleetsGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<GetFleetsResponse>) => r.body as GetFleetsResponse)
    );
  }

  /**
   * Gets a list of fleets.
   *
   *
   *
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiFleetsGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFleetsGet$Json$Response(params?: {
    request?: GetFleetsRequest;
  }): Observable<StrictHttpResponse<GetFleetsResponse>> {

    const rb = new RequestBuilder(this.rootUrl, FleetsService.ApiFleetsGetPath, 'get');
    if (params) {
      rb.query('request', params.request, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json'
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<GetFleetsResponse>;
      })
    );
  }

  /**
   * Gets a list of fleets.
   *
   *
   *
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiFleetsGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiFleetsGet$Json(params?: {
    request?: GetFleetsRequest;
  }): Observable<GetFleetsResponse> {

    return this.apiFleetsGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<GetFleetsResponse>) => r.body as GetFleetsResponse)
    );
  }

}
