import { TenantAvailabilityState, PageType, ContentPlace } from '@shared/service-proxies/service-proxies';


export class AppTenantAvailabilityState {
    static Available: number = TenantAvailabilityState._1;
    static InActive: number = TenantAvailabilityState._2;
    static NotFound: number = TenantAvailabilityState._3;
}

export class AppPageType {
    static Page: number = PageType._0;
    static News: number = PageType._1;
    static Article: number = PageType._2;
}

export class AppContentPlace {
    static Up: number = ContentPlace._0;
    static Middle: number = ContentPlace._1;
    static Bottom: number = ContentPlace._2;
}
