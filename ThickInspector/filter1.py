

import matplotlib.pyplot as plt
from scipy import signal
import numpy as np
import sys
#import logging
#log = logging.getLogger( 'Filter' )

class Filter():

    def __init__(self):

        pass
		
    
    def LoadData(self, fileName):
        dataDec = 0 #np.zeros((1))
        #print(type(dataDec))
        try:
            dataDec = np.genfromtxt(fileName, 
                                delimiter=',', 
                                dtype = np.float32,
                                skip_header = 3)
                                #missing_values = {0:''})
            #log.info( 'data shape : ')
            #log.info( dataDec.shape )
            print(type(dataDec))
        except:
            #log.error("CSV file data content error.")
            print("Please check data.")  
        return dataDec


    def LowPassFilter(self, data, cutoff, fs, order = 5):
        """
        param data: The data (numpy array) to be filtered.
        param cutoff: The high cutoff in Hz.
        param fs: The sample rate in Hz of the data.
        param order: The order of the filter. The higher the order, the tighter the roll-off.
        returns: Filtered data (numpy array).
        """
        print("fs="+str(fs))
        nyq = 0.5 * fs
        normal_cutoff = cutoff / nyq
        b, a = signal.butter(order, normal_cutoff, btype='low', analog=False)
        y = signal.lfilter(b, a, data)
        print(len(y))
        return y 


    def MovingAverage(self, data, order):
        """
        param data: The data (numpy array) to be filtered.
        param order: The order of the filter. The higher the order, the larger the average count.
        returns: Filtered data (numpy array).
        """
        if order < 1:
            print("Please makes order >= 1. We make order = 1 here.")
            order = 1
        cumsum = np.cumsum( np.insert(data, 0, 0) ) 
        y = ( cumsum[order:] - cumsum[:-order] ) / float(order)
        ins = y[0]
        
        for num in range(order-1): 
            y = np.insert(y, 0, ins)

        return y


    def PlotLine(self, y):
        lenx = len(y)
        x = np.arange(0,lenx)
        plt.plot(x,y)
        plt.ylim(70,100)
        #plt.show()

    def WriteData(self, path, data):
        with open(path, 

if __name__ == '__main__':
    #from Logger import Logger
    #logger = Logger('Filter', 'debug')
    #log.info("******* Start of Filter __main__ *******")
    print(sys.argv[1])
    c = Filter()
    data = c.LoadData(sys.argv[1]+".ori")
    
    print(data)
    filtered  = c.LowPassFilter(data[:,2:], 30, len(data)-2, 1)
    #movingAvg = c.MovingAverage(data[0], 5)
    filter.WriteData(sys.argv[1]+".csv", filtered[:,2:-3])
    
    c.PlotLine(data)
    c.PlotLine(filtered)
    #c.PlotLine(movingAvg)
    plt.show()

     
    #log.info("******* End of Filter __main__ *******")
    print("End of main")
