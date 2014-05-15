//
//  Globals.h
//  YAWYT
//
//  Created by Anthony Hart on 8/2/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Globals : NSObject

+(BOOL)isUserSignedIn;
+(void)setCurrUserName:(NSString *)userName andPassword:(NSString *)password;
+(void)clearCurrUserInfo;

@end
