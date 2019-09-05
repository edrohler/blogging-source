//-------------------------------------------------------------------------
// <Auto-generated file - do not modify!>
//
// This code was generated automatically by Kinvey Studio.
//
// Changes to this file may cause undesired behavior and will be lost
// the next time the code regenerates.
//
// Find more information on https://devcenter.kinvey.com/guides/studio-extension-points.
//-------------------------------------------------------------------------
import { Params, convertToParamMap } from '@angular/router';

import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { CollectionState } from '@src/app/core/data/state/collection-state.interface';
import { EntityState } from '@src/app/core/data/state/entity-state.interface';

export function mapRouterParamsToEntityState(params: Observable<Params>, idParam: string): Observable<EntityState> {
    return params.pipe(
        map((params: Params) => {
            const paramMap = convertToParamMap(params);
            return paramMap.has(idParam) ? { id: paramMap.get(idParam) } as EntityState : null;
        }),
        filter(v => !!v)
    );
}

export function findEntity(source: Observable<any>, idValueField: string, idKeyField?: string): Observable<EntityState> {
    return source.pipe(
        map(item => (!idKeyField || idKeyField === '_id' ? { id: item[idValueField] } : {
            filter: {
                logic: 'and',
                filters: [{
                    field: idKeyField,
                    operator: 'eq',
                    value: item[idValueField],
                    ignoreCase: false
                }]
            }
        }) as EntityState)
    )
}

export interface FilterCollectionOptions {
    source: Observable<any>;
    filterByField: string;
    filterValueField: string;
    take: number
}

export function filterCollectionByEntity({ source, filterByField, filterValueField, take }: FilterCollectionOptions): Observable<CollectionState> {
    return source.pipe(
        map(item => ({
            skip: 0,
            take,
            filter: {
                logic: 'or',
                filters: [
                    {
                        field: filterByField,
                        operator: 'eq',
                        value: item[filterValueField]
                    }
                ]
            }
        } as CollectionState))
    );
}
