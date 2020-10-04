import {
  TenantAvailabilityState,
  PageType,
  WidgetType,
  Position,
  SizeType,
} from "@shared/service-proxies/service-proxies";

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

export class AppWidgetType {
  static Container: number = WidgetType._0;
  static Html: number = WidgetType._1;
  static Image: number = WidgetType._2;
  static Paragraph: number = WidgetType._3;
  static Blockquote: number = WidgetType._4;
}

export class AppPosition {
  static Left: number = Position._0;
  static Center: number = Position._1;
  static Right: number = Position._2;
  static Justify: number = Position._3;
}

export class AppSizeType {
  static 25: number = SizeType._0;
  static 33: number = SizeType._1;
  static 50: number = SizeType._2;
  static 66: number = SizeType._3;
  static 75: number = SizeType._4;
  static 100: number = SizeType._5;
}
