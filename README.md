Scope:

Design:
http://www.appdesignvault.com/portfolio/quizen/

Deadline:
August 20th

Useful Code:
// implementing a +1 feature
```objective-c
JDTalk.h
@interface JDTalk : NSObject

@property NSString *phoneName;
@property NSString *modelNumber;
@property NSNumber *batteryLife;

- (void) decreasedBatteryLife;
- (void) reportBatteryLife;
- (NSString *) speak:(NSString *)greeting;

@end


```objective-c
#import "JDTalk.h"

@implementation JDTalk

- (void) decreaseBatteryLife;
{
  self.batteryLife = @([self.batteryLife intValue] - 1);
}

- (void) reportBatteryLife;
{
    NSLog(@"Battery life is %@", self.batteryLife);
}

- (NSString *)speak:(NSString *)greeting;
{
    NSString *message = [NSString stringWithFormat:@"%@ says %@", self.phoneName, greeting];
    return message;
}
@end

```objective-c
#import "JDTalk.h"

JDTalk *talkingiPhone = [[JDTalk alloc] init];
talkingiPhone.phoneName = @"Mr. Higgie";
talkingiPhone.batteryLife = @100;

[talkingiPhone decreaseBatteryLife];
[talkingiPhone reportBatteryLife];