//
//  TweetGrabber.h
//  YAWYT
//
//  Created by Anthony Hart on 8/2/13.
//  Copyright (c) 2013 Ursaware, LLC. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "TweetModel.h"

@interface TweetGrabber : NSObject

+(TweetModel*)MOCK_getRandomTweet:(TweetModel*)currTweet;
+(NSMutableArray*)MOCK_getRandomUserFullNames;

@end
