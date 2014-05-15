//
//  TweetModel.h
//  YAWYT
//
//  Created by Anthony Hart on 8/2/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface TweetModel : NSObject

@property (strong, nonatomic) NSString *text;
@property (strong, nonatomic) NSString *userFullName;

-(id)initWithText:(NSString*)text andUserFullName:(NSString*)userFullName;

@end
