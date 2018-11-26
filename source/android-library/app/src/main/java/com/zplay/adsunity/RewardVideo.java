/*
 * Copyright (C) 2016 Google, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package com.zplay.adsunity;

import com.zplay.adsunity.UnityRewardVideoAdListener;

import android.app.Activity;

import com.playableads.PlayLoadingListener;
import com.playableads.PlayPreloadingListener;
import com.playableads.PlayableAds;
import com.playableads.SimplePlayLoadingListener;

public class RewardVideo {
    private PlayableAds rewardVideo;
    private Activity activity;
    private UnityRewardVideoAdListener adListener;
    private final String appId;

    public RewardVideo(Activity activity, String appId, UnityRewardVideoAdListener adListener) {
        this.activity = activity;
        this.appId = appId;
        this.adListener = adListener;
        rewardVideo = PlayableAds.init(activity, appId);
    }

    public void loadAd(final String unitId) {
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                rewardVideo.requestPlayableAds(unitId, newRequestListener());
            }
        });
    }

    public boolean isLoaded(final String unitId) {
        return rewardVideo.canPresentAd(unitId);
    }

    public void show(final String unitId) {
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                if (rewardVideo.canPresentAd(unitId)) {
                    rewardVideo.presentPlayableAD(unitId, newPlayListener());
                }
            }
        });
    }

    public void setChannelId(final String channelId){
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                rewardVideo.setChannelId(channelId);
            }
        });
    }

    public void setAutoloadNext(final boolean autoLoad) {
        activity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                rewardVideo.setAutoLoadAd(autoLoad);
            }
        });
    }

    private PlayPreloadingListener newRequestListener() {

        return new PlayPreloadingListener() {

            @Override
            public void onLoadFinished() {
                if (adListener != null) {
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onAdLoaded();
                            }
                        }
                    }).start();
                }
            }

            @Override
            public void onLoadFailed(int errorCode, final String msg) {
                if (adListener != null) {
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onAdFailed(msg);
                            }
                        }
                    }).start();
                }
            }
        };
    }

    private PlayLoadingListener newPlayListener() {
        return new SimplePlayLoadingListener() {

            @Override
            public void onVideoStart() {
                if (adListener != null) {
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onAdStarted();
                            }
                        }
                    }).start();
                }
            }

            @Override
            public void playableAdsIncentive() {
                if (adListener != null) {
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onAdRewarded();
                            }
                        }
                    }).start();
                }
            }

            @Override
            public void onVideoFinished() {
                if (adListener != null) {
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onAdVideoCompleted();
                            }
                        }
                    }).start();
                }
            }

            @Override
            public void onLandingPageInstallBtnClicked() {
                if (adListener != null) {
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onAdClicked();
                            }
                        }
                    }).start();
                }
            }

            @Override
            public void onAdClosed() {
                if (adListener != null) {
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onAdCompleted();
                            }
                        }
                    }).start();
                }
            }

            @Override
            public void onAdsError(int code, final String msg) {
                if (adListener != null) {
                    new Thread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onAdFailed(msg);
                            }
                        }
                    }).start();
                }
            }
        };
    }
}